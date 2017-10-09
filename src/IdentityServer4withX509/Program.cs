using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore;

namespace IdentityServer4withX509
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer4 using X509";

            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:5000")
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}