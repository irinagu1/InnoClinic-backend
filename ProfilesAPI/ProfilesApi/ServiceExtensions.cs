using Contracts;
using Intercommunication.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using ProfilesApi.Infrastructure.ErrorHandlers;
using Repository;
using Serilog;
using Services;
using Services.AsyncCommunication;
using Services.Contracts;

namespace ProfilesApi;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureRabbitMQ
        (this IServiceCollection services)
    {
        services.AddSingleton<IConnectionProvider, ConnectionProvider>();  
        services.AddScoped<IChannelProvider, ChannelProvider>();          
        services.AddScoped(typeof(IQueueChannelProvider<>), typeof(QueueChannelProvider<>));  
        services.AddScoped(typeof(IQueueProducer<>), typeof(QueueProducer<>));                

        return services;
    }

    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo{Title="Profiles API", Version="v1"});
            });
        return services;
    }

    public static IServiceCollection ConfigureExceptionHandlers(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<MsSqlDbExceptionHandler>();
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
                path: "logs/log-profilesApi-.txt", 
                rollingInterval: RollingInterval.Day,
                outputTemplate: customTemplate,
                shared: true) 
            );
        return host;
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    
    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();
    

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

}