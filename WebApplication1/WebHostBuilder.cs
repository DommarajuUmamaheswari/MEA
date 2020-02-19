using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Momentum.External.Api
{
    public static class WebHostBuilder
    {
        public const string EnvironmentVariableConfigPrefix = "Momentum_External_API_";

        static string GetEnvironmentName() =>
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        public static (IConfigurationBuilder builder, string environmentName) CreateBuilder(string[] args) =>
            CreateBuilder(Directory.GetCurrentDirectory(), GetEnvironmentName, args);

        public static (IConfigurationBuilder builder, string environmentName) CreateBuilder(
            string fileProviderBasePath,
            Func<string> getEnvironmentName,
            string[] args)
        {
            var environment = getEnvironmentName();

            var builder = new ConfigurationBuilder()
                .SetBasePath(fileProviderBasePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true);

            if (string.Equals(environment, "Development", StringComparison.OrdinalIgnoreCase))
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables(prefix: EnvironmentVariableConfigPrefix)
                .AddCommandLine(args);

            return (builder, environment);

        }

    }
}
