using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TinyCloneFunction.Services
{
    public class UrlService : IUrlService
    {
        private ILogger _logger;

        public UrlService(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<string> CreateUrl(string devKey, string originalUrl)
        {
            _logger.LogInformation("CreateUrl");

            // dummy data for now
            return await Task.FromResult("12345678");
        }
    }
}
