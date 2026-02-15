using Serilog.Context;

namespace OfficesApi.Presentation;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private const string HeaderName = "X-Correlation-Id";

    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string CorrelationId = Guid.NewGuid().ToString();
        context.Response.Headers[HeaderName] = CorrelationId;
        using(LogContext.PushProperty("CorrelationId", CorrelationId))
        {
            await _next(context);
        }
    }
}