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
            //var connectionString = "DefaultEndpointsProtocol=https;AccountName=tiny-storage;AccountKey=es04nLCyKpDflFwXboGImsNrNBY5JngQrkcl7qNsvUGWTiRZDFXHq70u0fDFtBxkdLHkhorET7f4h9JnClI4cg==;TableEndpoint=https://tiny-storage.table.cosmos.azure.com:443/;";

            ServiceProvider provider = (Service.ConfigureServices() as ServiceCollection)
                                            .AddSingleton<ILogger, DummyLogger>()
                                            .BuildServiceProvider();

            var userStore = provider.GetService<IUserStore>();

            var user = userStore.GetUsers();

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
