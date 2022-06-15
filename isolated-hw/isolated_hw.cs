using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace isolated_hw
{
    public class isolated_hw
    {
        private readonly ILogger _logger;

        public isolated_hw(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<isolated_hw>();
        }

        [Function("isolated_hw")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString($"Welcome to Azure Functions! got the {req.Method} request from {req.Url}");

            return response;
        }
    }
}
