namespace Shared.ResultPattern;

public static class AuthErrors
{
    public static Error EmailAlreadyExist(string email) =>
        new Error("Account.EmailAlreadyExists", $"An account with email: {email} already exists in a system");

}
