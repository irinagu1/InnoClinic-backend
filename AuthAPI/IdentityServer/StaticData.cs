using Duende.IdentityModel;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer.StaticData;

public static class SD
{
    public const string Admin ="admin";
    public const string Customer ="Customer";

        //по сути это группа клеймов для доступа к скоуп
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
        //    new IdentityResource("role", new [] { JwtClaimTypes.Role }) //скоуп и тип клейма
        };

        public static IEnumerable<ApiScope> ApiScopes() =>
            new List<ApiScope>
        {
            //идентификаторы ресурсов в системе, к которому клиент может запросить доступ
            //скоупы бывают: идентити скоупс(профайл пользователя) и ресурс скоупс
            new ApiScope("api1", "My API"),
         /*   new ApiScope("roles", "USer roles for api access")
            {
                UserClaims = {"role"}
            }*/
        };

    public static IEnumerable<Client> Clients()
    {
        return new List<Client>
        {
            //различные типы приложения
            //клиент может запрашивать идентити токены и токены доступа
            
            new Client
            {
                ClientId = "bff",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                // where to redirect to after login
                RedirectUris = { "https://localhost:5229/signin-oidc", "https://localhost:5173/signin-oidc",
                "https://localhost:5174/signin-oidc"
                }, //"https://localhost:5173/signin-oidc"

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:5229/signout-callback-oidc",
                "https://localhost:5173/signout-callback-oidc",
                "https://localhost:5174/signout-callback-oidc"  },
                AllowOfflineAccess = true,

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                    //JwtClaimTypes.Role,
                    "customRole",
                    "api1"
                }
            },

           
        };
    }
}