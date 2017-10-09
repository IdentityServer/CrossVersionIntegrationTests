using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore;

namespace IdentityServer4withRSA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer4 using RSA";

            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:5001")
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}
