using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace FormsIW5.IdentityProvider.App
{
    // ALl these files should be replaced by a database in real production
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources
        {
            get
            {
                var profileIdentityResources = new IdentityResources.Profile();
                profileIdentityResources.UserClaims.Add("username");

                return
                [
                    new IdentityResources.OpenId(),
                    profileIdentityResources
                ];
            }
        }

        public static IEnumerable<ApiResource> ApiResources =>
        [
            new ("cookbookclientaudience")
        ];

        public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ("iw5FormsScope", [JwtClaimTypes.Role])
        ];

        public static IEnumerable<Client> Clients = new List<Client>()
        {
            new Client(){
                    ClientName = "Forms IW5 Web Client",
                    ClientId = "Iw5FormsClient",
                    AllowOfflineAccess = true,
                    RedirectUris =
                    [
                        "https://oauth.pstmn.io/v1/callback"
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
                        "iw5FormsScope"
                    ],
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RequireClientSecret = false
                }
             };
    }
}
