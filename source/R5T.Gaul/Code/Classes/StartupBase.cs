using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace R5T.Gaul
{
    public abstract class StartupBase : IStartup
    {
        protected ILogger Logger { get; }


        public StartupBase(ILogger<StartupBase> logger)
        {
            this.Logger = logger;
        }

        public void ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
            this.ConfigureConfigurationBody(configurationBuilder);
        }

        /// <summary>
        /// Base implementation does nothing.
        /// </summary>
        protected virtual void ConfigureConfigurationBody(IConfigurationBuilder configurationBuilder)
        {
            // Do nothing.
        }

        public void ConfigureServices(IServiceCollection services)
        {
            this.ConfigureServicesBody(services);
        }

        /// <summary>
        /// Base implementation does nothing.
        /// </summary>
        protected virtual void ConfigureServicesBody(IServiceCollection services)
        {
            // Do nothing.
        }

        public void Configure(IServiceProvider serviceProvider)
        {
            this.ConfigureBody(serviceProvider);
        }

        /// <summary>
        /// Base implementation does nothing.
        /// </summary>
        protected virtual void ConfigureBody(IServiceProvider serviceProvider)
        {
            // Do nothing.
        }
    }
}
