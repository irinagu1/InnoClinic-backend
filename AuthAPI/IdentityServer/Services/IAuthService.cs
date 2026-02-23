namespace IdentityServer.Services;

public interface IAuthService
{
    Task<bool> CheckIfEmailExistsAsync(string email);
}