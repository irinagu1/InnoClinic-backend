using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Testcontainers.MsSql;

namespace IntegrationTests.Fixtures;

public class DockerWebApplicationFactoryFixture : WebApplicationFactory<ProfilesApi.AssemblyMarker>, IAsyncLifetime
{
    private readonly MsSqlContainer _dbContainer;

    public int InitialDoctorsCount { get; set; } = 5;

    public DockerWebApplicationFactoryFixture()
    {
        _dbContainer = new MsSqlBuilder("mcr.microsoft.com/mssql/server:2022-CU10-ubuntu-22.04").Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var _connectionString = _dbContainer.GetConnectionString();
        base.ConfigureWebHost(builder);

        builder.ConfigureTestServices(services =>
                {
                    var descriptors = services.Where(d => 
                            d.ServiceType == typeof(DbContextOptions<RepositoryContext>) || 
                            d.ServiceType.Name.Contains("IDbContextOptionsConfiguration") ||
                            d.ServiceType == typeof(RepositoryContext))
                            .ToList();

                    foreach (var descriptor in descriptors)
                        services.Remove(descriptor);

                    services.AddDbContext<RepositoryContext>(opt =>
                    {
                        opt.UseSqlServer(_connectionString);
                    });
                });
    }
    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();

        await using (var scope = Services.CreateAsyncScope())
        {
            var scopedServices = scope.ServiceProvider;
            var dbContext = scopedServices.GetRequiredService<RepositoryContext>();

            await dbContext.Database.EnsureCreatedAsync();
            await dbContext.Doctors!.AddRangeAsync(DataFixture.GetDoctors(InitialDoctorsCount));
            await dbContext.SaveChangesAsync();
        }
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }
}