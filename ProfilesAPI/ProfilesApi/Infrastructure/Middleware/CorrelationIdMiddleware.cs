using Microsoft.Extensions.Primitives;
using Serilog.Context;

namespace ProfilesApi.Infrastructure.Middleware;

public class CorrelationIdMiddleware(RequestDelegate next)
{
    private const string CorrelationIdHeaderName = "Correlation-Id";

    public async Task InvokeAsync(HttpContext context)
    {
        using(LogContext.PushProperty("CorrelationId", GetCorrelationId(context)))
        {
            await next(context);
        }
    }

    private static string GetCorrelationId(HttpContext context)
    {
        context.Request.Headers.TryGetValue(
            CorrelationIdHeaderName, 
            out StringValues correlationId);
        
        return correlationId.FirstOrDefault() ?? context.TraceIdentifier;
    }
}