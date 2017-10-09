using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore;

namespace CoreApiIdSrv4withX509
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Core API using IS3";

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:5052")
                .UseStartup<Startup>()
                .Build();
    }
}