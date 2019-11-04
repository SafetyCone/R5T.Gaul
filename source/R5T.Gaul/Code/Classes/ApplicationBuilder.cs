using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Sardinia;

using R5T.Gaul.Extensions;


namespace R5T.Gaul
{
    public static class ApplicationBuilder
    {
        public static IServiceProvider UseStartup<TStartup>()
            where TStartup: class, IApplicationStartup
        {
            // Build the standard startup.
            var applicationStartup = ApplicationBuilder.GetApplicationStartup<TStartup>();

            // Configuration.
            var applicationConfigurationBuilder = new ConfigurationBuilder();

            applicationStartup.ConfigureConfiguration(applicationConfigurationBuilder);

            var applicationConfiguration = applicationConfigurationBuilder.Build();

            // Configure services.
            var applicationServices = new ServiceCollection();

            applicationServices.AddConfiguration(applicationConfiguration); // Allow the startup class to access its configuration as a service during configuration of services.

            applicationStartup.ConfigureServices(applicationServices);

            var applicationServiceProvider = applicationServices.BuildServiceProvider();

            // Configure service instances.
            applicationStartup.Configure(applicationServiceProvider);

            return applicationServiceProvider;
        }

        public static TStartup GetApplicationStartup<TStartup>()
            where TStartup: class, IApplicationStartup
        {
            var startupConfiguration = ApplicationBuilder.GetStartupConfiguration();

            var startupServiceProvider = ApplicationBuilder.GetStartupServiceProvider<TStartup>(startupConfiguration);

            var applicationStartup = startupServiceProvider.GetRequiredService<TStartup>();
            return applicationStartup;
        }

        private static IServiceProvider GetStartupServiceProvider<TStartup>(IConfiguration configuration)
            where TStartup: class, IApplicationStartup
        {
            var serviceProvider = new ServiceCollection()
                .AddConfiguration(configuration)
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConsole();
                })
                .AddStartup<TStartup>()
                .BuildServiceProvider();

            return serviceProvider;
        }

        private static IConfiguration GetStartupConfiguration()
        {
            var startupConfiguration = new ConfigurationBuilder()
                .Build();

            return startupConfiguration;
        }
    }
}
