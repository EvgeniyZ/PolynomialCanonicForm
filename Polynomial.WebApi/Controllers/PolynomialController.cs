using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Polynomial.WebApi.Services;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using Polynomial.WebApi.Helpers;
using Polynomial.WebApi.Models;

namespace Polynomial.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolynomialController : ControllerBase
    {
        private readonly CanonicalFormer _canonicalFormer;
        private readonly BlockingCollection<ExpressionBlock> _expressionsQueue;
        private readonly BlockingCollection<ExpressionBlock> _canonicalQueue;

        public PolynomialController(CanonicalFormer canonicalFormer)
        {
            _canonicalFormer = canonicalFormer;
            _expressionsQueue = new BlockingCollection<ExpressionBlock>();
            _canonicalQueue = new BlockingCollection<ExpressionBlock>();
        }

        [HttpPost]
        public IActionResult GetCanonical([FromBody] ExpressionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            (string canonical, string errorMessage) = _canonicalFormer.ToCanonical(model.Expression);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return Ok(canonical);
        }

        [HttpPost("fromfile")]
        public async Task<IActionResult> GetCanonicalsFromFile()
        {
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                ModelState.AddModelError("File",
                    $"The request couldn't be processed. Unknown content type");

                return BadRequest(ModelState);
            }

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(Request.ContentType));
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);

            var consumeTask = ConsumeExpressionsQueue();
            var section = await reader.ReadNextSectionAsync();
            var expressionsCount = 0;

            while (section != null)
            {
                using (var streamReader = new StreamReader(
                    section.Body,
                    Encoding.ASCII,
                    detectEncodingFromByteOrderMarks: true,
                    -1,
                    leaveOpen: true))
                {
                    while (!streamReader.EndOfStream)
                    {
                        // don't think it's useful to readLineAsync because async\await has an overhead
                        string expression = streamReader.ReadLine();
                        _expressionsQueue.Add(new ExpressionBlock
                        {
                            Expression = expression,
                            Id = expressionsCount
                        });
                        expressionsCount++;
                    }
                }

                section = await reader.ReadNextSectionAsync();
            }

            _expressionsQueue.CompleteAdding();
            await consumeTask;

            while (_canonicalQueue.Count < expressionsCount)
            {
                await Task.Delay(100);
            }

            var outputStream = new MemoryStream(_canonicalQueue.OrderBy(x => x.Id).SelectMany(x => Encoding.ASCII.GetBytes($"{x.Expression}\n")).ToArray());
            return new FileStreamResult(outputStream, new MediaTypeHeaderValue("application/octet-stream"))
            {
                FileDownloadName = "canonicals.txt"
            };
            // var outputStream = new GZipStream(), CompressionMode.Compress);
            // return new FileStreamResult(outputStream, new MediaTypeHeaderValue("application/octet-stream"))
            // {
            //     FileDownloadName = "canonicals.zip"
            // };
        }

        private Task ConsumeExpressionsQueue()
        {
            return Task.Run(() =>
            {
                Parallel.ForEach(_expressionsQueue.GetConsumingEnumerable(),
                    new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount},
                    (expressionBlock, state) =>
                    {
                        var canonicalFormer = new CanonicalFormer();

                        (string canonical, string errorMessage) = canonicalFormer.ToCanonical(expressionBlock.Expression);

                        _canonicalQueue.Add(new ExpressionBlock
                        {
                            Expression = string.IsNullOrEmpty(errorMessage) ? canonical : errorMessage,
                            Id = expressionBlock.Id
                        });
                    });
            });
        }
    }
}