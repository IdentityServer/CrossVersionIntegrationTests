using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace IdentityServer4withRSA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer4 using RSA";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:5001")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
