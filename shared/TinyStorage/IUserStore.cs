using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyStorage.Entities;

namespace TinyStorage
{
    public interface IUserStore
    {
        Task<bool> UserExists(string name, string email);

        Task<UserEntity> CreateUser(string name, string email);

        Task<UserEntity> GetUser(string name, string email);

        // TODO: Probably can execute as task
        IEnumerable<UserEntity> GetUsers();
    }
}
