﻿using System;
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

        public PolynomialController(CanonicalFormer canonicalFormer)
        {
            _canonicalFormer = canonicalFormer;
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

            var expressionsQueue = new BlockingCollection<ExpressionBlock>();
            var canonicalQueue = new BlockingCollection<ExpressionBlock>();

            var consumeTask = ConsumeExpressionsQueue(expressionsQueue, canonicalQueue);
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
                        expressionsQueue.Add(new ExpressionBlock
                        {
                            Expression = expression,
                            Id = expressionsCount
                        });
                        expressionsCount++;
                    }
                }

                section = await reader.ReadNextSectionAsync();
            }

            expressionsQueue.CompleteAdding();
            await consumeTask;

            var outputStream = new MemoryStream(canonicalQueue.OrderBy(x => x.Id)
                .SelectMany(x => Encoding.ASCII.GetBytes($"{x.Expression}\n"))
                .ToArray());
            return new FileStreamResult(outputStream, new MediaTypeHeaderValue("application/octet-stream"))
            {
                FileDownloadName = "canonicals.txt"
            };
        }

        private static Task ConsumeExpressionsQueue(BlockingCollection<ExpressionBlock> expressionsQueue, BlockingCollection<ExpressionBlock> canonicalQueue)
        {
            return Task.Run(() =>
            {
                Parallel.ForEach(expressionsQueue.GetConsumingEnumerable(),
                    new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount},
                    (expressionBlock) =>
                    {
                        var canonicalFormer = new CanonicalFormer();

                        (string canonical, string errorMessage) = canonicalFormer.ToCanonical(expressionBlock.Expression);

                        canonicalQueue.Add(new ExpressionBlock
                        {
                            Expression = string.IsNullOrEmpty(errorMessage) ? canonical : errorMessage,
                            Id = expressionBlock.Id
                        });
                    });
            });
        }
    }
}