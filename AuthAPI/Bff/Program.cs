using Duende.Bff;
using Duende.Bff.DynamicFrontends;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBff()
  .AddFrontends(
    new BffFrontend(BffFrontendName.Parse("clientfront"))
          .WithCdnIndexHtmlUrl(new Uri("https://localhost:5173")),
    new BffFrontend(BffFrontendName.Parse("adminfront"))
          .WithCdnIndexHtmlUrl(new Uri("https://localhost:5174"))
  );
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "cookie_clientfront";
    options.DefaultChallengeScheme = "oidc_clientfront";
    options.DefaultSignOutScheme = "oidc_clientfront";
})
.AddCookie("cookie_clientfront", options =>
{
    options.Cookie.Name = "__Host-bff";
    options.Cookie.SameSite = SameSiteMode.Strict;
})
.AddOpenIdConnect("oidc_clientfront", options =>
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



builder.Services.AddAuthorization();
*/

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
// app.UseRouting();
app.UseBff();
app.UseAuthorization();
app.MapBffManagementEndpoints();

app.MapFallbackToFile("/index.html");
app.Run();
