using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new[] { new ApiScope("api1", "WebApi") };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource
                {
                    Scopes = new List<string> { "api1" },
                    DisplayName = "WebApi",
                    Name = "api1"
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
                    AllowedScopes = { "api1", "openid", "profile" },
                    RedirectUris = { "https://chat.local/signin-oidc" },
                    PostLogoutRedirectUris = { "https://chat.local" },
                    AllowedCorsOrigins = { "https://chat.local" },
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
