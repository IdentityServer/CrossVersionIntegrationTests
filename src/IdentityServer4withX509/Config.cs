using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4withX509
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api")
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

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api" }
                }
            };
        }
    }
}