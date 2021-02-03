using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;

namespace TinyCloneFunction
{
    public static class UrlFunction
    {
        //private static async Task<string> GetAccessTokenAsync(string authority, string resource, string scope)
        //{
        //    var clientCredential = new ClientCredential(Constants.Vault.AppId, Constants.Vault.AppSecret);

        //    var context = new AuthenticationContext(authority, TokenCache.DefaultShared);

        //    AuthenticationResult result = await context.AcquireTokenAsync(resource, clientCredential);

        //    return result.AccessToken;

        //}
        [FunctionName("UrlFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("PEW PEW PEW PEW PEW PEW");            
            //try
            //{
            //    Azure.Core.TokenCredential
            //    SecretClient client = new SecretClient(new Uri("https://tiny-clone-vault.vault.azure.net"), new DefaultAzureCredential());
            //    AsyncPageable<SecretProperties> allSecrets = client.GetPropertiesOfSecretsAsync();

            //    await foreach (SecretProperties secretProperties in allSecrets)
            //    {
            //        Console.WriteLine(secretProperties.Name);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return new BadRequestResult();
            //}

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

            return new ContentResult() { Content = "FOKKIT!" };
        }
    }
}
