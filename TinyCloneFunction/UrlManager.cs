using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TinyCloneFunction
{
    public class UrlManager
    {
        private ILogger _logger;

        public UrlManager(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<string> CreateUrl(string devKey, string originalUrl)
        {
            _logger.LogInformation("CreateUrl");

            // dummy data for now
            return await Task.FromResult("12345678");
        }

        public async Task<bool> DeleteUrl(string devKey, string shortUrl)
        {
            _logger.LogInformation("DeleteUrl");

            return await Task.FromResult(false);
        }
    }
}
