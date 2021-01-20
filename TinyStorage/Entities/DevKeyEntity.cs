using System;
using System.Collections.Generic;
using System.Text;

namespace TinyStorage.Entities
{
    public class DevKeyEntity
    {
        public DevKeyEntity()
        {
        }

        public DevKeyEntity(int userId, string devKey)
        {
            this.UserId = userId;
            this.DevKey = devKey;
        }

        public int UserId { get; set; }

        public string DevKey { get; set; }
    }
}
