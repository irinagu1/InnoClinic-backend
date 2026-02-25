using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer.StaticData;

public static class SD
{
    public const string Admin ="admin";
    public const string Customer ="customer";
    public const string Doctor = "doctor";
    public const string Receptionist = "receptionist";


    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource("https://localhost:5001/resources") 
            {
                Scopes = { "officesAPI" } 
            }
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),   
            new IdentityResource(
    	        name: "customRole",
    	        userClaims: new[] { "role" },
    	        displayName: "role info")
        };

        public static IEnumerable<ApiScope> ApiScopes() =>
            new List<ApiScope>
        {
            new ApiScope("officesAPI", "Offices API"),
        };

    public static IEnumerable<Client> Clients()
    {
        return new List<Client>
        {
            new Client
            {
                ClientId = "bff",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { 
                    "https://localhost:5229/signin-oidc", 
                    "https://localhost:5174/admin/signin-oidc",
                    "https://localhost:5173/client/signin-oidc"
                }, 

                PostLogoutRedirectUris = { 
                    "https://localhost:5229/signout-callback-oidc",
                    "https://localhost:5174/admin/signout-callback-oidc",
                    "https://localhost:5173/client/signout-callback-oidc",
                },
                AllowOfflineAccess = true,

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                    "customRole",
                    "officesAPI"
                }
            },
        };
    }
}