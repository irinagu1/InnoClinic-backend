using System.Security.Claims;
using Duende.IdentityModel;
using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.StaticData;

public class CustomProfileService : ProfileService<ApplicationUser>
{
    private readonly UserManager<ApplicationUser> _userManager;
 //   private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;

    public CustomProfileService(
        UserManager<ApplicationUser> userManager,
       // RoleManager<IdentityRole> roleManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory)
        : base(userManager, userClaimsPrincipalFactory)
    {
        _userManager = userManager;
     //   _roleManager = roleManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
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
                //claims.Add(new Claim(JwtClaimTypes.Role, rolename));
            }
        }
        id.AddClaim(new Claim("myclaim", "myclain"));
      /*  ClaimsPrincipal userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);
        List<Claim> claims = userClaims.Claims.ToList();
        claims = claims.Where(u=> context.RequestedClaimTypes.Contains(u.Type)).ToList();
        claims.Add(new Claim(JwtClaimTypes.Name, user.UserName));
        if (_userManager.SupportsUserRole)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            foreach(var rolename in roles)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, rolename));
            }
        }
*/
        //context.IssuedClaims = claims;
             context.IssuedClaims.AddRange(principal.Claims);
        //context.AddRequestedClaims(principal.Claims);
    }

/*    public async Task IsActiveAsync(IsActiveContext context)
    {
        string sub = context.Subject.GetSubjectId();
        ApplicationUser user = await _userManager.FindByIdAsync(sub);
        context.IsActive = user != null;
    }*/
}