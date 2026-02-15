using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OfficesApi.Shared;

namespace OfficesApi.Presentation;

internal sealed class MongoDbExceptionHandler(
    IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not MongoDbException validationException)
            return false;
        
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var context = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Type = "NongoDbException",
                Title = "MongoDb error",
                Detail = "MongoDb error has occurred"
            }
        };
        
        return await problemDetailsService.TryWriteAsync(context);
    }
}