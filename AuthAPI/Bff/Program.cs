using Duende.Bff;
using Duende.Bff.DynamicFrontends;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

var builder = WebApplication.CreateBuilder(args);

var bffBuilder = builder.Services.AddBff();

bffBuilder.AddFrontends(
    new BffFrontend(BffFrontendName.Parse("clientfront"))
        .MapToPath("/client") 
        .WithCdnIndexHtmlUrl(new Uri("https://localhost:5173")),

    new BffFrontend(BffFrontendName.Parse("adminfront"))
        .MapToPath("/admin")
        .WithCdnIndexHtmlUrl(new Uri("https://localhost:5174"))
);

bffBuilder
    .ConfigureOpenIdConnect(options => {
        options.Authority = "https://localhost:5001"; 
        options.ClientId = "bff";
        options.ClientSecret = "secret";
        options.ResponseType = "code";

        options.Scope.Add("api1");
        options.Scope.Add("customRole");
        options.Scope.Add("offline_access");

        options.GetClaimsFromUserInfoEndpoint = true;
        options.MapInboundClaims = false;
        options.SaveTokens = true;
        options.DisableTelemetry = true;

        options.TokenValidationParameters.RoleClaimType = "role";
        options.TokenValidationParameters.NameClaimType = "name";
        options.ClaimActions.Add(new JsonKeyClaimAction("role", null, "role"));
    })
    .ConfigureCookies(options => {
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });


builder.Services.AddAuthorization();

/*
builder.Services.AddBff();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "cookie";
    options.DefaultChallengeScheme = "oidc";
    options.DefaultSignOutScheme = "oidc";
}).AddCookie("cookie", options =>
{
    options.Cookie.Name = "__Host-bff";
    options.Cookie.SameSite = SameSiteMode.Strict;
}).AddOpenIdConnect("oidc", options =>
{
        options.Authority = "https://localhost:5001"; 
     options.ClientId = "bff";
        options.ClientSecret = "secret";
        options.ResponseType = "code";
 //   options.ResponseMode = "query";

   options.Scope.Add("api1");
        options.Scope.Add("customRole");
        options.Scope.Add("offline_access");


    options.GetClaimsFromUserInfoEndpoint = true;
    options.MapInboundClaims = false;
    options.SaveTokens = true;
    options.DisableTelemetry = true;



     options.TokenValidationParameters.RoleClaimType = "role";
        options.TokenValidationParameters.NameClaimType = "name";
        options.ClaimActions.Add(new JsonKeyClaimAction("role", null, "role"));
       
});



builder.Services.AddAuthorization();*/


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseBff();
app.UseAuthorization();
app.MapBffManagementEndpoints();

app.MapFallbackToFile("/index.html");
app.Run();
