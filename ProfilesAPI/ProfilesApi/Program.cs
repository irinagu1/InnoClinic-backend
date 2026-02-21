using AutoMapper;
using ProfilesApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(ProfilesApi.Presentation.AssemblyMarker).Assembly);

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();

app.Run();
