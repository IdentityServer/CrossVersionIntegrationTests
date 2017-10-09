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
            Console.Title = "Katana API using IS4 and X509";

            using (WebApp.Start<Startup>("http://localhost:6050"))
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
                Authority = "http://localhost:5000",
                RequiredScopes = new[] { "api" },

                DelayLoadMetadata = true
            });

            app.UseWebApi(config);
        }
    }
}