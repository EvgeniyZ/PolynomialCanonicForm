using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Polynomial.WebApi.Services;
using System.Collections.Concurrent;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polynomial.WebApi.Helpers;
using Polynomial.WebApi.Models;

namespace Polynomial.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolynomialController : ControllerBase
    {
        private readonly CanonicalFormer _canonicalFormer;
        private readonly BlockingCollection<string> _expressionsQueue;
        private readonly BlockingCollection<string> _canonicalQueue;

        public PolynomialController(CanonicalFormer canonicalFormer)
        {
            _canonicalFormer = canonicalFormer;
            _expressionsQueue = new BlockingCollection<string>();
            _canonicalQueue = new BlockingCollection<string>();
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

            StartWorkers();
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
                    // don't think it's useful to readLineAsync cause async\await has overhead
                    string expression = streamReader.ReadLine();
                    streamReader.ReadLine();
                    expressionsCount++;
                    _expressionsQueue.Add(expression);
                }

                section = await reader.ReadNextSectionAsync();
            }

            _expressionsQueue.CompleteAdding();

            while (_canonicalQueue.Count < expressionsCount)
            {
                await Task.Delay(100);
            }

            var outputStream = new GZipStream(new MemoryStream(_canonicalQueue.SelectMany(x => Encoding.ASCII.GetBytes(x)).ToArray()), CompressionMode.Compress);
            return new FileStreamResult(outputStream, new MediaTypeHeaderValue("application/octet-stream"))
            {
                FileDownloadName = "canonicals.zip"
            };
        }

        private void StartWorkers()
        {
            Parallel.ForEach(_expressionsQueue.GetConsumingEnumerable(), (expression, state) =>
            {
                var canonicalFormer = new CanonicalFormer();

                (string canonical, string errorMessage) = canonicalFormer.ToCanonical(expression);

                _canonicalQueue.Add(string.IsNullOrEmpty(errorMessage) ? canonical : errorMessage);
            });
        }
    }
}