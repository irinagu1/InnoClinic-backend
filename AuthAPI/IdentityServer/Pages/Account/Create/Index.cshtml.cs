using System.Security.Claims;
using Duende.IdentityModel;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Test;
using IdentityServer.Models;
using IdentityServer.StaticData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace src.Pages.Create;

[SecurityHeaders]
[AllowAnonymous]
public class Index : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    [BindProperty]
    public InputModel Input { get; set; }

    public Index(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager
        )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> OnGet(string returnUrl)
    {
        List<string> roles = new List<string>()
        {
            SD.Admin,
            SD.Customer
        };
        
        ViewData["roles_message"] = roles;

        Input = new InputModel { ReturnUrl = returnUrl };

        return Page();
    }

    public async Task<IActionResult> OnPost(string returnUrl)
    {
        ViewData["roles_message"]= new List<string>()
        {
            SD.Admin,
            SD.Customer
        };

        if (ModelState.IsValid)
        {
            var user = new ApplicationUser()
            {
                UserName=Input.Email,
                Email = Input.Email,
                EmailConfirmed = true,
                PhoneNumber="1111111" 
            };

            var result = await _userManager.CreateAsync(user, Input.Password);
            if(result.Succeeded)
            {
                if(!_roleManager.RoleExistsAsync(Input.RoleName).GetAwaiter().GetResult())
                {
                    var userRole = new IdentityRole
                    {
                        Name = Input.RoleName,
                        NormalizedName= Input.RoleName,
                    };
                    await _roleManager.CreateAsync(userRole); 
                }
                await _userManager.AddToRoleAsync(user, Input.RoleName);

                await _userManager.AddClaimsAsync(user, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, Input.Email),
                    new Claim(JwtClaimTypes.Email, Input.Email),
                    new Claim(JwtClaimTypes.Role, Input.RoleName)
                });

                var loginresult = await _signInManager.PasswordSignInAsync(
                    Input.Email, Input.Password, false, lockoutOnFailure: true
                );
                if (loginresult.Succeeded)
                {
                    if (Url.IsLocalUrl(Input.ReturnUrl))
                    {
                        return Redirect(Input.ReturnUrl);
                    }
                    else if (string.IsNullOrEmpty(Input.ReturnUrl))
                    {
                        return Redirect("~/");
                    }
                    else
                    {
                        throw new Exception("invalid return url");
                    }
                }
            }
        }
        else
        {
               var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
               foreach(var e in errors)
            {
                System.Console.WriteLine($"--> {e}");
            }
        }
        return Redirect("~/");
    }
}
  