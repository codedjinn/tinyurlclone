using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TinyCloneFunction.Services
{
    public interface IUrlService
    {
        Task<string> CreateUrl(string devKey, string originalUrl);
    }
}
