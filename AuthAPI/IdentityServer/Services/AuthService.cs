using System.Security.Claims;
using Duende.IdentityModel;
using IdentityServer.Models;
using IdentityServer.RabbitMQ.Events;
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

    public async Task<string> CreateNewAccountAndReturnIdAsync(UserToCreateEvent @event)
    {
        var pass = "Admin123!";

        var doctor = new ApplicationUser()
        {
            UserName = @event.email,
            Email = @event.email,
            EmailConfirmed = true,
            PhoneNumber="1"
        };
        var result = await _userManager.CreateAsync(doctor, pass);
        if(result.Succeeded)
        {
            await _userManager.AddToRoleAsync(doctor, @event.userType);
            await _userManager.AddClaimsAsync(doctor,
            [
                new Claim(JwtClaimTypes.Name, @event.email),
                new Claim(JwtClaimTypes.Email, @event.email),
                new Claim(JwtClaimTypes.Role, @event.userType)
            ]);            
            return doctor.Id;
        }
        
        throw new Exception();
    }
}