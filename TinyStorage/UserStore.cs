using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyStorage.Entities;

namespace TinyStorage
{
    public class UserStore : IUserStore
    {
        private ILogger _logger;
        private ITableService _tableService;

        public UserStore(ILogger logger,
                         ITableService tableService)
        {
            _logger = logger;
            _tableService = tableService; 
        }

        public async Task<UserEntity> CreateUser(string name, string email)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            try
            {
                if (!(await UserExists(name, email)))
                {
                    var table = _tableService.GetTable(UserEntity.TableName);

                    var entity = new UserEntity(name, email);
                    entity.DevKey = this.GenerateApiKey(name);

                    var operation = TableOperation.InsertOrMerge(entity);

                    // just simple demo so this should be sufficient

                    var result = await table.ExecuteAsync(operation);
                    if (result.Result != null)
                    {
                        return (UserEntity)result.Result;
                    }
                }
            }
            catch (StorageException storageEx)
            {
                _logger.LogError(storageEx.Message);
                throw;
            }

            return null;
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            var result = new List<UserEntity>();
            try
            {
                var table = _tableService.GetTable(UserEntity.TableName);
                TableContinuationToken token = null;
                do
                {
                    var queryResult = table.ExecuteQuerySegmented(new TableQuery<UserEntity>(), token);
                    result.AddRange(queryResult.Results);
                    token = queryResult.ContinuationToken;
                } while (token != null);
            }
            catch (StorageException storageEx)
            {
                _logger.LogError(storageEx.Message);
                throw;
            }
            return result;
        }

        public async Task<bool> UserExists(string name, string email)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            try
            {
                var table = _tableService.GetTable(UserEntity.TableName);
                var operation = TableOperation.Retrieve(name, email);
                var result = await table.ExecuteAsync(operation);
                if (result.Result != null)
                {
                    return true;
                }
            }
            catch (StorageException storageEx)
            {
                _logger.LogError(storageEx.Message);
                throw;
            }

            return false;
        }

        private string GenerateApiKey(string name)
        {
            byte[] bytes = System.Text.UTF8Encoding.UTF8.GetBytes(name);
            using var sha = System.Security.Cryptography.SHA256.Create();
            return System.Convert.ToBase64String(sha.ComputeHash(bytes));
        }
    }
}
