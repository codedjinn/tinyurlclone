using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TinyStorage;

namespace Testing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ServiceProvider provider = (Service.ConfigureServices() as ServiceCollection)
                                            .AddSingleton<ILogger, DummyLogger>()
                                            .BuildServiceProvider();


            var configService = provider.GetService<IConfigurationService>();
            configService.Add("AzureTableStorageConnection", "DefaultEndpointsProtocol=https;AccountName=tiny-clone-tables;AccountKey=SJmvQVR88WFCzpEoUxHlqalYcAtLe2ncisXeH6QCTHmvQCcFGh448xk7u67EQsqM5zZg1qaR45S3QQxxWILjxQ==;TableEndpoint=https://tiny-clone-tables.table.cosmos.azure.com:443/;");
           
            var userStore = provider.GetService<IUserStore>();
            var user = await userStore.GetUser("entity", "ent@mail.com");
            //var result = await userStore.CreateUser("entity", "ent@mail.com");
            //var users = userStore.GetUsers();

            //var mgr = new TinyStorage.Manager(connectionString, new DummyLogger());
            //var users = mgr.GetUsers();
            //await mgr.CreateUser("user1", "asd@asd.asd");
        }
    }

    class DummyLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return new Dis();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

        }

        class Dis : IDisposable
        {
            public void Dispose()
            {
            }
        }

    }
}
