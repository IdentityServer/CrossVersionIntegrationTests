using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore;

namespace CoreApiIdSrv4withX509
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Core API using IS4 RSA";

            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:5051")
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}