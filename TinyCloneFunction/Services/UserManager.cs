using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TinyCloneFunction.Services
{
    public class UserService : IUserService
    {
        public Task<bool> CreateUser(string email, string user)
        {
            return Task.FromResult(false);
        }
    }
}
