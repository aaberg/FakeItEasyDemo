using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using StarWarsServices;
using StarWasProxy;

namespace StarWarsCli
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            
            ConfigureServices(services);

            using var serviceProvider = services.BuildServiceProvider();
            
            var app = serviceProvider.GetService<App>() ?? throw new Exception("App not configured");
            var appTask = app.RunAsync();
            appTask.Wait();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<HttpClient>();
            services.AddScoped<ISwapiProxy, SwapiProxy>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddTransient<App>();
        }
    }
}