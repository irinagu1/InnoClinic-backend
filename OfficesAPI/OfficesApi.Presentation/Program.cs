using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;
using OfficesApi.Application.Abstractions.Behaviour;
using OfficesApi.Infrastructure.MongoDb;
using OfficesApi.Presentation;
using Serilog;

var AdminClientAppCors = "AdminClientAppCors";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.Authority = "https://localhost:5001";
        opt.Audience = "https://localhost:5001/resources";
    });

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("OfficesAuthPolicy", policy =>
        {
          policy.RequireAuthenticatedUser()
            .RequireRole("admin");
        });
    });

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: AdminClientAppCors, policy =>
    {
        policy.WithOrigins("https://localhost:5174")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Host.ConfigureLogging();

builder.Services.AddScoped<TrackExecutionTimeAttribute>();

builder.Services.ConfigureExceptionHandlers();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(OfficesApi.Application.MappingProfile).Assembly);

builder.Services.AddMediatR(cfg => 
    {
        cfg.RegisterServicesFromAssembly(typeof(OfficesApi.Application.AssemblyMarker).Assembly);

        cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
    });
        
builder.Services.ConfigureMongoDb(builder.Configuration);

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo{Title="Offices API", Version="v1"});

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    opt.IncludeXmlComments(xmlPath);

    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

   opt.AddSecurityRequirement(document => new OpenApiSecurityRequirement
{
    [new OpenApiSecuritySchemeReference("Bearer", document)] = new List<string>()
});
});

builder.Services.AddValidatorsFromAssembly(typeof(OfficesApi.Application.AssemblyMarker).Assembly);

builder.Services.AddScoped<IHelperService, HelperService>();

var app = builder.Build();

app.UseMiddleware<CorrelationIdMiddleware>();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AdminClientAppCors);

app.MapControllers();

app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Started HTTP {Method} {Path} request" ,context.Request.Method, context.Request.Path);

    await next.Invoke();
});

app.Run();
