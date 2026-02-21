using Microsoft.AspNetCore.Diagnostics;

namespace ProfilesApi.Infrastructure.ErrorHandlers;

internal sealed class ValidationExceptionHandler
    (IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync
        (HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        return false;
    }
}