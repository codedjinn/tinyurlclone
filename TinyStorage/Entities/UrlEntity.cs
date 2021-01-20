using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;


namespace TinyStorage.Entities
{
    public class UrlEntity : TableEntity
    {
        public UrlEntity()
        {
        }

        public UrlEntity(
                    string shortUrl,
                    string originalUrl,
                    int userId,
                    DateTime created)
        {
            this.ShortUrl = shortUrl;
            this.OriginalUrl = originalUrl;
            this.UserId = userId;
            this.Created = created;
        }


        public string ShortUrl { get; set; }

        public string OriginalUrl { get; set; }

        public int UserId { get; set; }

        public DateTime Created { get; set; }
    }
}

