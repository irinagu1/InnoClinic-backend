using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using OfficesApi.Application;
using OfficesApi.Application.Abstractions.Behaviour;
using OfficesApi.Presentation;

var builder = WebApplication.CreateBuilder(args);

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

});


builder.Services.AddValidatorsFromAssembly(typeof(OfficesApi.Application.AssemblyMarker).Assembly);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ValidationExceptionHandlingMiddleware>();
app.MapControllers();



app.Run();



public sealed class ValidationExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(ValidationException ex)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "ValidationFailure",
                Title = "Validation error",
                Detail = "One or more validation errors has occurred"
            };
            if (ex.Errors is not null)
            {
                problemDetails.Extensions["errors"] = ex.Errors;
            }
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

}