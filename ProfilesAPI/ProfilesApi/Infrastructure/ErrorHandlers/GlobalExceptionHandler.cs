using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ProfilesApi.Infrastructure.ErrorHandlers;

internal sealed class GlobalExceptionHandler
    (IProblemDetailsService problemDetailsService,
    ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync
        (HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var context = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = exception.GetType().Name,
                Title = "A Server error occured",
            }
        };
        
        string methodType = httpContext.Request.Method;
        string path = httpContext.Request.Path.HasValue ? httpContext.Request.Path.Value : "no path";

        logger.LogError("Global exception occured for method {@Method}, path {@Path}, error: {@Err}",
            methodType, 
            path,
            exception.Message);

        return await problemDetailsService.TryWriteAsync(context);
    }
}