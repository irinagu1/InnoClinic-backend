using System.Security.Claims;
using Duende.IdentityModel;
using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.StaticData;

public class CustomProfileService : ProfileService<ApplicationUser>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CustomProfileService(
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory)
        : base(userManager, userClaimsPrincipalFactory)
    {
        _userManager = userManager;
    }    

    protected override async Task GetProfileDataAsync(ProfileDataRequestContext context, ApplicationUser user1)
    {
        string sub = context.Subject.GetSubjectId();
        ApplicationUser user = await _userManager.FindByIdAsync(sub);

        var principal = await GetUserClaimsAsync(user);
        var id = (ClaimsIdentity)principal.Identity;

          if (_userManager.SupportsUserRole)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            foreach(var rolename in roles)
            {
                id.AddClaim(new Claim(JwtClaimTypes.Role, rolename));
            }
        }
        id.AddClaim(new Claim("myclaim", "myclain"));
    
        context.IssuedClaims.AddRange(principal.Claims);
    }
}