using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GarbageService
{
    public static class TestParameters
    {
        [FunctionName("TestParameters")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "naam/{myname}")] HttpRequest req, string myname,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult($"Hello , {myname}");
         
        }
    }
}
