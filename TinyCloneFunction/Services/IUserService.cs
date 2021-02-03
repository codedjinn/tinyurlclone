using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TinyCloneFunction.Services
{
    public interface IUserService
    {
        Task<bool> CreateUser(string email, string user);
    }
}
