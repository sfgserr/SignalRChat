using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new[] { new ApiScope("MessageApi.read"), new ApiScope("MessageApi.write") };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> { "role" }
                }
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("MessageApi")
                {
                    Scopes = new List<string> { "MessageApi.read", "MessageApi.write" },
                    ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256()) },
                    UserClaims = new List<string> { "role" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "chat.client",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                    AllowedScopes = { "MessageApi.read", "MessageApi.write", "openid", "profile" },
                    RedirectUris = { "http://127.0.0.1/signin-oidc" },
                    AllowOfflineAccess = true,
                }
            };
    }
}
