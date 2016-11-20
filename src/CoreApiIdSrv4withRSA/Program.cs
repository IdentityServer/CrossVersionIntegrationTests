using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace CoreApiIdSrv4withX509
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Core API using IS4 RSA";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:5051")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
