using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4withRSA
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api")
                {
                    ApiSecrets = { new Secret("secret".Sha256()) }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // JWT
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api" }
                },
                // reference
                new Client
                {
                    ClientId = "client.reference",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api" },

                    AccessTokenType = AccessTokenType.Reference
                }
            };
        }
    }
}