using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new[] { new ApiScope("messageapi.read"), new ApiScope("messageapi.full_access") };

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
                new ApiResource
                {
                    Scopes = new List<string> { "messageapi.read", "messageapi.full_access" },
                    Name = "api"
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
                    AllowedScopes = { "messageapi.read", "messageapi.full_access", "openid", "profile" },
                    RedirectUris = { "https://chat.local/signin-oidc" },
                    PostLogoutRedirectUris = { "https://chat.local" },
                    AllowedCorsOrigins = { "https://chat.local" },
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,
                    RequirePkce = true,
                }
            };
    }
}
