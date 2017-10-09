using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace IdentityServer4withX509
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var certPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "idsrvtest.pfx");

            services.AddIdentityServer()
                .AddSigningCredential(new X509Certificate2(certPath))
                .AddInMemoryApiResources(Config.GetApis())
                .AddInMemoryClients(Config.GetClients());
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseIdentityServer();
        }
    }
}
