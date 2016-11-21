using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace CoreApiIdSrv4withX509
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Core API using IS3";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:5052")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
