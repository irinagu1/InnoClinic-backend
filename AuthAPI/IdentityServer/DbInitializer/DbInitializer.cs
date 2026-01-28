using Duende.IdentityModel;
using IdentityServer.Models;
using IdentityServer.StaticData;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Db;


public class DbInitializer : IDbInitializer
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public DbInitializer(ApplicationDbContext applicationDbContext,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
    {
        _db= applicationDbContext;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void Initialize()
    {
        if (_roleManager.FindByNameAsync(SD.Admin).Result == null)
        {
            _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
        }
        else
            return;
        
        ApplicationUser adminUser = new()
        {
            UserName="ad@mail.ru",
            Email="ad@mail.ru",
            EmailConfirmed = true,
            PhoneNumber="11111111"
        };
        _userManager.CreateAsync(adminUser, "Admin123!").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

        var claims1 = _userManager.AddClaimsAsync(adminUser, new System.Security.Claims.Claim[]
        {
            new System.Security.Claims.Claim(JwtClaimTypes.NickName, adminUser.UserName),
            new System.Security.Claims.Claim(JwtClaimTypes.Role, SD.Admin),
        }).Result;

         ApplicationUser customerUser = new()
        {
            UserName="us@mail.ru",
            Email="us@mail.ru",
            EmailConfirmed = true,
            PhoneNumber="11111111"
        };
        _userManager.CreateAsync(customerUser, "Admin123!").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(customerUser, SD.Customer).GetAwaiter().GetResult();

        var claims2 = _userManager.AddClaimsAsync(customerUser, new System.Security.Claims.Claim[]
        {
            new System.Security.Claims.Claim(JwtClaimTypes.NickName, customerUser.UserName),
            new System.Security.Claims.Claim(JwtClaimTypes.Role, SD.Customer),
        }).Result;
    }

}