using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TinyStorage
{
    public static class Service
    {
        public static IServiceCollection ConfigureServices()
        {
            return new ServiceCollection()
                        .AddSingleton<ITableService, TableService>()
                        .AddSingleton<IUserStore, UserStore>();
        }
    }
}
