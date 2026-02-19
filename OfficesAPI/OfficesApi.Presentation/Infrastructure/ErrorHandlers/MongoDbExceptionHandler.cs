using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
namespace OfficesApi.Presentation;

internal sealed class MongoDbExceptionHandler(
    ILogger<MongoDbExceptionHandler> logger,
    IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not MongoException mongoException)
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
                Detail = $"Message: {exception.Message}"
            }
        };
        
        string methodType = httpContext.Request.Method;
        string path = httpContext.Request.Path.HasValue ? httpContext.Request.Path.Value : "no path";

        logger.LogError("MongoDb error occured for method {@Method}, path {@Path}, error(s): {@Err}",
            methodType, 
            path,
            exception.Message);


        return await problemDetailsService.TryWriteAsync(context);
    }
}