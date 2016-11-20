using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace IdentityServer4withRSA
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var certPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "idsrvtest.pfx");

            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryScopes(Config.GetScopes())
                .AddInMemoryClients(Config.GetClients());
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Information);

            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();
        }
    }
}
