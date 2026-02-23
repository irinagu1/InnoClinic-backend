using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> CheckIfEmailExistsAsync(string email)
    {
        var userWithEmail = await _userManager.FindByEmailAsync(email);
        if(userWithEmail is null)
            return false;
        else
            return true;
    }
}