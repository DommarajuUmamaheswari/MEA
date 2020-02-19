using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Momentum.External.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var (configBuilder, environmentName) = WebHostBuilder.CreateBuilder(args);

            var config = configBuilder.Build();

            var host = CreateConfigurableWebHostBuilder(args, config)
                .UseEnvironment(environmentName)
                .Build();

            host.Run();
        }

        public static IWebHostBuilder CreateConfigurableWebHostBuilder(string[] args, IConfiguration configuration = null) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureAppConfiguration(config =>
            {
                config.AddConfiguration(configuration ?? WebHostBuilder.CreateBuilder(args).builder.Build());
            });

    }
}
