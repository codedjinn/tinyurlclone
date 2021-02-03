using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TinyStorage
{
    public interface ITableService
    {
        CloudTable GetTable(string tableName);

        Task<CloudTable> CreateTable(string tableName);
    }
}
