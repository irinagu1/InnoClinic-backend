using FluentValidation;
using ProfilesApi;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging();
builder.Services.ConfigureExceptionHandlers();

builder.Services.AddControllers()
    .AddApplicationPart(typeof(ProfilesApi.Presentation.AssemblyMarker).Assembly);

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddValidatorsFromAssembly(typeof(Services.AssemblyMarker).Assembly);

builder.Services.ConfigureSwagger();

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseExceptionHandler();

app.UseHsts();
app.UseHttpsRedirection();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
