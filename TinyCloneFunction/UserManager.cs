using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TinyCloneFunction
{
    public class UserManager
    {
        private ILogger _logger;

        public UserManager(ILogger logger)
        {
            _logger = logger;
        }

        //public async Task<UserEntity> GetUser(string name, string email)
        //{
        //    //var userStore = new UserStore(_logger, new TableService(_logger));
        //    //return await userStore.GetUser(name, email);
        //}
    }
}
