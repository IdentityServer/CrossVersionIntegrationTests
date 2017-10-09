using IdentityServer3.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace IdentityServer3Host
{
    class Config
    {
        public static IEnumerable<Scope> GetScopes()
        {
            return new List<Scope>
            {
                new Scope
                {
                    Name = "api",
                    ScopeSecrets = { new Secret("secret".Sha256()) }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    Flow = Flows.ClientCredentials,
                    AllowedScopes = { "api" }
                },

                new Client
                {
                    ClientId = "client.reference",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    Flow = Flows.ClientCredentials,
                    AllowedScopes = { "api" },

                    AccessTokenType = AccessTokenType.Reference
                }
            };
        }

        public static X509Certificate2 GetCertificate()
        {
            var assembly = typeof(Config).Assembly;
            using (var stream = assembly.GetManifestResourceStream("IdentityServer3Host.idsrvtest.pfx"))
            {
                return new X509Certificate2(ReadStream(stream));
            }
        }

        private static byte[] ReadStream(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    }
}
