using Serilog;

namespace OfficesApi.Presentation;

public static class ExtensionMethods
{
    public static IServiceCollection ConfigureExceptionHandlers(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<MongoDbExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();


        return services;    
    }

    public static IHostBuilder ConfigureLogging(this IHostBuilder host)
    {
        string customTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] [{CorrelationId}] {Message:lj}{NewLine}{Exception}";

        host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()  
            .WriteTo.Console(outputTemplate: customTemplate)
            .WriteTo.File(
                path: "logs/log-officesApi-.txt", 
                rollingInterval: RollingInterval.Day,
                outputTemplate: customTemplate,
                shared: true) 
            );
        return host;
    }
}