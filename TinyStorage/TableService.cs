using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace TinyStorage
{
    public class TableService : ITableService
    {
        private ILogger _logger;

        public TableService(ILogger logger)
        {
            _logger = logger;
        }

        public CloudTable GetTable(string tableName)
        {
            var storageAccount = this.GetStorageAccount();
            var tableClient = storageAccount.CreateCloudTableClient();
            return tableClient.GetTableReference(tableName);
        }

        private CloudStorageAccount GetStorageAccount()
        {
            CloudStorageAccount result = null;
            try
            {
                result = CloudStorageAccount.Parse(Settings.Instance.Connections.AzureTableStorage);
            }
            catch (FormatException fex)
            {
                _logger.LogError($"Invalid storage account info provided. Reason - {fex.Message}");
                throw;
            }
            catch (ArgumentException aex)
            {
                _logger.LogError($"Invalid storage account info provided. Reason - {aex.Message}");
                throw;
            }
            return result;
        }

        public async Task<CloudTable> CreateTable(string tableName)
        {
            var storageAccount = this.GetStorageAccount();

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());

            CloudTable table = tableClient.GetTableReference(tableName);
            if (await table.CreateIfNotExistsAsync())
            {
                _logger.LogInformation($"Table '{tableName}' created.");
            }
            else
            {
                _logger.LogInformation($"Table '{tableName}' already exists.");
            }

            return table;
        }
    }
}
