using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyStorage.Entities;

namespace TinyStorage
{
    public class Manager
    {
        private string _connectionStr;
        private ILogger _logger;

        private ServiceProvider _provider;

        public Manager(string connectionStr, ILogger logger)
        {
            _connectionStr = connectionStr;
            _logger = logger;

            
        }

        //public async Task<T> CreateEntity<T>(ITableEntity entity) where T : ITableEntity
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException(nameof(entity));
        //    }

        //    try
        //    {
        //        var table = this.GetTable("");
        //        var operation = TableOperation.Insert(entity);

        //        TableResult result = await table.ExecuteAsync(operation);
        //        return (T)result.Result;
        //    }
        //    catch (StorageException storageEx)
        //    {
        //        _logger.LogError(storageEx.Message);
        //        throw;
        //    }
        //}

        //public async Task EnsureTables()
        //{
        //    await CreateTable("Url");
        //    await CreateTable("User");
        //    await CreateTable("DevKey");
        //}
       
    }
}
