using IdentityModel.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestClient
{
    public class Program
    {
        static TestCase[] cases = new[]
        {
            new TestCase
            {
                Description = "IdentityServer4 using X509 certificate",
                TokenEndpoint = "http://localhost:5000/connect/token",

                Apis =
                {
                    new Api
                    {
                        Description = "ASP.NET Core",
                        ClientId = "client",
                        Url = "http://localhost:5050"
                    },
                    new Api
                    {
                        Description = "Katana",
                        ClientId = "client",
                        Url = "http://localhost:6050"
                    }
                }
            },
            new TestCase
            {
                Description = "IdentityServer4 using RSA key",
                TokenEndpoint = "http://localhost:5001/connect/token",

                Apis =
                {
                    new Api
                    {
                        Description = "ASP.NET Core (JWT)",
                        ClientId = "client",
                        Url = "http://localhost:5051"
                    },
                    new Api
                    {
                        Description = "Katana",
                        ClientId = "client",
                        Url = "http://localhost:6051"
                    },
                    new Api
                    {
                        Description = "ASP.NET Core (reference)",
                        ClientId = "client.reference",
                        Url = "http://localhost:5051"
                    },
                    new Api
                    {
                        Description = "Katana (reference)",
                        ClientId = "client.reference",
                        Url = "http://localhost:6051"
                    }
                }
            },
            new TestCase
            {
                Description = "IdentityServer3",
                TokenEndpoint = "http://localhost:5002/connect/token",

                Apis =
                {
                    new Api
                    {
                        Description = "ASP.NET Core (JWT)",
                        ClientId = "client",
                        Url = "http://localhost:5052"
                    },
                    new Api
                    {
                        Description = "ASP.NET Core (reference)",
                        ClientId = "client.reference",
                        Url = "http://localhost:5052"
                    },
                    new Api
                    {
                        Description = "Katana (JWT)",
                        ClientId = "client",
                        Url = "http://localhost:6052"
                    },
                    new Api
                    {
                        Description = "Katana (reference)",
                        ClientId = "client.reference",
                        Url = "http://localhost:6052"
                    }
                }
            }
        };

        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        public static async Task MainAsync()
        {
            Console.Title = "Test Client";

            Console.WriteLine("press enter to start...\n\n");
            Console.ReadLine();

            foreach (var test in cases)
            {
                Console.WriteLine($"Test:           {test.Description}\n");

                foreach (var api in test.Apis)
                {
                    var token = await GetToken(test.TokenEndpoint, api.ClientId);

                    Console.WriteLine($"API:            {api.Description}");

                    await CallApi(api.Url, token);
                }

                Console.WriteLine("\n\n");
            }
        }

        private static async Task<string> GetToken(string endpoint, string clientId)
        {
            var tokenClient = new TokenClient(endpoint, clientId, "secret");
            var response = await tokenClient.RequestClientCredentialsAsync("api");

            if (response.IsError)
            {
                throw new Exception(response.Error);
            }

            return response.AccessToken;
        }

        private static async Task CallApi(string api, string token)
        {
            var client = new HttpClient();
            client.SetBearerToken(token);

            var response = await client.GetStringAsync(api + "/test");

            Console.WriteLine("OK");
        }
    }

    public class TestCase
    {
        public string Description { get; set; }
        public string TokenEndpoint { get; set; }

        public ICollection<Api> Apis { get; set; } = new HashSet<Api>();
    }

    public class Api
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
    }
}
