using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

public class TrackExecutionTimeAttribute : IAsyncActionFilter
{
    private Stopwatch? _stopwatch;
    private readonly ILogger<TrackExecutionTimeAttribute> _logger;
    
    public TrackExecutionTimeAttribute(ILogger<TrackExecutionTimeAttribute> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _stopwatch = Stopwatch.StartNew();

        await next.Invoke();
        
        _stopwatch?.Stop();
        var elapsedMilliseconds = _stopwatch?.ElapsedMilliseconds;
        var actionName = context.ActionDescriptor.DisplayName;

        _logger.LogInformation("Method {@ActionName} is done for {@Time} ms", actionName, elapsedMilliseconds);
    }
}