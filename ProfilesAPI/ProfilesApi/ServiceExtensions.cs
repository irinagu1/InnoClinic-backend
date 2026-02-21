using Contracts;
using Microsoft.EntityFrameworkCore;
using ProfilesApi.Infrastructure.ErrorHandlers;
using Repository;
using Services;
using Services.Contracts;

namespace ProfilesApi;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureErrorHandlers(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<MsSqlDbExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();

        return services;
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    
    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

}