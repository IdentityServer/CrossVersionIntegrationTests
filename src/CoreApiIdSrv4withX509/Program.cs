using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore;

namespace CoreApiIdSrv4withX509
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Core API using IS4 X509";

            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:5050")
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}
