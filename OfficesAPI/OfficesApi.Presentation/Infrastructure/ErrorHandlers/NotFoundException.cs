using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OfficesApi.Shared;

namespace OfficesApi.Presentation;
internal sealed class NotFoundExceptionHandler(
    IProblemDetailsService problemDetailsService, 
    ILogger<NotFoundExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not NotFoundException)
            return false;

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        var context = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Type = exception.GetType().Name,
                Title = "Not found exception",
                Detail = exception.Message
            }
        };

        string methodType = httpContext.Request.Method;
        string path = httpContext.Request.Path.HasValue ? httpContext.Request.Path.Value : "no path";

        logger.LogError("Validation error occured for method {@Method}, path {@Path}, error(s): {@Err}",
            methodType, 
            path,
            exception.Message);

        return await problemDetailsService.TryWriteAsync(context);
    }
}