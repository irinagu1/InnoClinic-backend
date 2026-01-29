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

        if(_roleManager.FindByNameAsync(SD.Doctor).Result == null)
        {
            _roleManager.CreateAsync(new IdentityRole(SD.Receptionist)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Doctor)).GetAwaiter().GetResult();
        }
        else
            return;
        
        //doctor
        ApplicationUser doctorUser = new()
        {
            UserName="doc@mail.ru",
            Email="doc@mail.ru",
            EmailConfirmed = true,
            PhoneNumber="11111111"
        };
        _userManager.CreateAsync(doctorUser, "Admin123!").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(doctorUser, SD.Admin).GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(doctorUser, SD.Doctor).GetAwaiter().GetResult();

        var claimsDoctor = _userManager.AddClaimsAsync(doctorUser, new System.Security.Claims.Claim[]
        {
            new System.Security.Claims.Claim(JwtClaimTypes.NickName, doctorUser.UserName),
            new System.Security.Claims.Claim(JwtClaimTypes.Role, SD.Admin),
            new System.Security.Claims.Claim(JwtClaimTypes.Role, SD.Doctor),
        }).Result;

        //receptionist
        ApplicationUser receptionistUser = new()
        {
            UserName="rec@mail.ru",
            Email="rec@mail.ru",
            EmailConfirmed = true,
            PhoneNumber="11111111"
        };
        _userManager.CreateAsync(receptionistUser, "Admin123!").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(receptionistUser, SD.Admin).GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(receptionistUser, SD.Doctor).GetAwaiter().GetResult();

        var claimsRec = _userManager.AddClaimsAsync(receptionistUser, new System.Security.Claims.Claim[]
        {
            new System.Security.Claims.Claim(JwtClaimTypes.NickName, receptionistUser.UserName),
            new System.Security.Claims.Claim(JwtClaimTypes.Role, SD.Admin),
            new System.Security.Claims.Claim(JwtClaimTypes.Role, SD.Receptionist),
        }).Result;

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