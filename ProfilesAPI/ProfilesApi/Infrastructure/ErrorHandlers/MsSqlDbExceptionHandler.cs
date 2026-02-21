using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ProfilesApi.Infrastructure.ErrorHandlers;

internal sealed class MsSqlDbExceptionHandler
    (IProblemDetailsService problemDetailsService) : IExceptionHandler
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
        
        return await problemDetailsService.TryWriteAsync(context);
    }
}