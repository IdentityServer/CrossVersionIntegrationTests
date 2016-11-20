using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace IdentityServer4withX509
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer4 using X509";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:5000")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}