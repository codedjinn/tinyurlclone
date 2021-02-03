using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TinyCloneFunction
{
    public static class UserFunction
    {
        [FunctionName("UserFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            
            string response = null;

            string type = req.Query["type"];
            if (string.IsNullOrEmpty(type))
            {
                string msg = "'type' parameter was null or empty";
                log.LogInformation(msg);
                return new BadRequestResult();
            }

            return await Task.FromResult(new OkObjectResult(response));
        }
    }
}
