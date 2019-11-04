using System;

using Microsoft.Extensions.Logging;


namespace R5T.Gaul
{
    public abstract class ApplicationStartupBase : StartupBase, IApplicationStartup
    {
        public ApplicationStartupBase(ILogger<ApplicationStartupBase> logger)
            : base(logger)
        {
        }
    }
}
