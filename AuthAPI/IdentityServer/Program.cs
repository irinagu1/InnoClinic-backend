using Duende.IdentityServer.Services;
using IdentityServer.Db;
using IdentityServer.Models;
using IdentityServer.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();

builder.Services.AddIdentityServer(opt =>
{
    opt.Events.RaiseErrorEvents=true;
    opt.Events.RaiseInformationEvents=true;
    opt.Events.RaiseFailureEvents=true;
    opt.Events.RaiseSuccessEvents=true;
    opt.EmitStaticAudienceClaim=true;
})
.AddInMemoryIdentityResources(SD.IdentityResources)
.AddInMemoryApiScopes(SD.ApiScopes())
.AddInMemoryClients(SD.Clients())
.AddAspNetIdentity<ApplicationUser>()
.AddDeveloperSigningCredential()
.AddProfileService<CustomProfileService>();

//builder.Services.AddScoped<IProfileService, ProfileSerive>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

SeedData();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages();//.RequireAutorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

void SeedData()
{
    System.Console.WriteLine("--> Seeding data");
    using(var scope = app.Services.CreateScope())
    {
        var dbInit = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInit.Initialize();
    }
}