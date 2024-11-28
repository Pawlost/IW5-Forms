using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace FormsIW5.IdentityProvider.App
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
                [
                    new ("formsiw5", [JwtClaimTypes.Role])
                ];

        public static IEnumerable<Client> Clients =>
            [
                 new()
                {
                    ClientName = "FormsIW5 Client",
                    ClientId = "formsiw5client",
                    AllowOfflineAccess = true,
                    RedirectUris =
                    [
                        "https://oauth.pstmn.io/v1/callback",
                        "https://localhost:44355/authentication/login-callback",
                    ],
                    AllowedGrantTypes =
                    [
                        GrantType.ClientCredentials,
                        GrantType.ResourceOwnerPassword,
                        GrantType.AuthorizationCode
                    ],
                    RequirePkce = true,
                    AllowedScopes =
                    [
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "formsiw5"
                    ],
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
         ];
    }
}