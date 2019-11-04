using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace R5T.Gaul
{
    public interface IStartup
    {
        void ConfigureConfiguration(IConfigurationBuilder configurationBuilder);
        void ConfigureServices(IServiceCollection services);
        void Configure(IServiceProvider serviceProvider); // Does this work in WebApplications?
    }
}
