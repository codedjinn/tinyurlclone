using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace TinyStorage.Entities
{
    public class UserEntity : TableEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(string name, string email)
        {
            this.PartitionKey = name;
            this.RowKey = email;
        }

        [Microsoft.Azure.Cosmos.Table.IgnoreProperty]
        public string Name
        {
            get
            {
                return this.PartitionKey;
            }
        }

        [Microsoft.Azure.Cosmos.Table.IgnoreProperty]
        public string Email
        {
            get
            {
                return this.RowKey;
            }
        }

        public string LastLogin { get; set; }

        public string DevKey { get; set; }

        public static string TableName => "User";
    }
}
