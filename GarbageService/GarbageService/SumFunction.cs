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
    public static class SumFunction
    {
        [FunctionName("SumFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "calculator/sum/{number1}/{number2}")] HttpRequest req, int number1,
            int number2, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Getallen data = JsonConvert.DeserializeObject<Getallen>(requestBody);
            int som = data.Getal1 + data.Getal2;
            return new OkObjectResult(som);
        }
    }
}
