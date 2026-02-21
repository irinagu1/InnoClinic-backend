using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ProfilesApi.Infrastructure.ErrorHandlers;

internal sealed class MsSqlDbExceptionHandler
    (IProblemDetailsService problemDetailsService,
    ILogger<MsSqlDbExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync
        (HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not DbUpdateException efException)
            return false;

        string title = "MS SQL Database error";
        string type = "EfCoreDbException";
        string detail = efException.Message;

        if (efException.InnerException is SqlException sqlEx)
        {
            type = "SqlServerException";
            title = $"SQL Error (Code {sqlEx.Number})";
            detail = sqlEx.Message;
        }

        var context = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Type = type,
                Title = title,
                Detail = detail,
                Instance = httpContext.Request.Path
            }
        };

        string methodType = httpContext.Request.Method;
        string path = httpContext.Request.Path.HasValue ? httpContext.Request.Path.Value : "no path";

        logger.LogError("MSSQL DB error occured for method {@Method}, path {@Path}, error(s): {@Err}",
            methodType, 
            path,
            exception.Message);
        
        return await problemDetailsService.TryWriteAsync(context);
    }
}