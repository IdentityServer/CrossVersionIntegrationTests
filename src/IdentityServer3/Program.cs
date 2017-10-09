using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.InMemory;
using Microsoft.Owin.Hosting;
using Owin;
using Serilog;
using System;
using System.Collections.Generic;

namespace IdentityServer3Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IdentityServer3";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.LiterateConsole()
                .CreateLogger();

            using (WebApp.Start<Startup>("http://localhost:5002"))
            {
                Console.ReadLine();
            }
        }
    }

    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var factory = new IdentityServerServiceFactory()
                .UseInMemoryScopes(Config.GetScopes())
                .UseInMemoryClients(Config.GetClients())
                .UseInMemoryUsers(new List<InMemoryUser>());

            var options = new IdentityServerOptions
            {
                Factory = factory,
                SigningCertificate = Config.GetCertificate(),
                RequireSsl = false
            };

            app.UseIdentityServer(options);
        }
    }
}