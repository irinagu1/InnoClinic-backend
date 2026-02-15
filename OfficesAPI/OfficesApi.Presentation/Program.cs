using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using OfficesApi.Application;
using OfficesApi.Application.Abstractions.Behaviour;
using OfficesApi.Presentation;

var builder = WebApplication.CreateBuilder(args);

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

});

builder.Services.AddValidatorsFromAssembly(typeof(OfficesApi.Application.AssemblyMarker).Assembly);

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
