using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace func_urls
{
    public static class UrlFunction
    {
        [FunctionName("UrlFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string response = null;

            string type = req.Query["type"];

            if (string.IsNullOrEmpty(type))
            {
                log.LogWarning("'type' parameter was null or empty.");
                return new BadRequestResult();
            }

            // shared parmater

            string devKey = req.Query["devKey"];
            if (string.IsNullOrEmpty(devKey))
            {
                log.LogWarning("'devkey' parameter was null or empty");
                return new BadRequestResult();
            }
            
            if (type.Equals("create", StringComparison.OrdinalIgnoreCase))
            {
                string originalUrl = req.Query["originalUrl"];
                if (string.IsNullOrEmpty(originalUrl))
                {
                    log.LogWarning("'devkey' parameter was null or empty");
                    return new BadRequestResult();
                }

                var urlManager = new UrlManager(log);
                var url = await urlManager.CreateUrl(devKey, originalUrl);
                response = url;
            }
            else if (type.Equals("delete", StringComparison.OrdinalIgnoreCase))
            {
                string shortUrl = req.Query["shortUrl"];
                if (string.IsNullOrEmpty(shortUrl))
                {
                    log.LogWarning("'devkey' parameter was null or empty");
                    return new BadRequestResult();
                }

                var urlManager = new UrlManager(log);
                await urlManager.DeleteUrl(devKey, shortUrl);
            }
            else
            {
                string msg = $"No action of type '{type}' found.";
                log.LogInformation(msg);
                return new NotFoundObjectResult(msg);
            }

            return new OkObjectResult(response);
        }
    }
}
