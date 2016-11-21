using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Logging;
using Owin;
using System;
using System.Web.Http;

namespace KatanaApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Katana API using IS3";

            using (WebApp.Start<Startup>("http://localhost:6052"))
            {
                Console.ReadLine();
            }
        }
    }

    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.SetLoggerFactory(new ConsoleLoggerFactory());

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:5002",
                RequiredScopes = new[] { "api" },

                ClientId = "api",
                ClientSecret = "secret",

                DelayLoadMetadata = true
            });

            app.UseWebApi(config);
        }
    }
}