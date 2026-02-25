using IdentityServer.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureDb(builder.Configuration);
builder.Services.ConfigureIdentityServer();

builder.Services.ConfigureSwagger();

builder.Services.RegisterServices();

builder.Services.ConfigureRabbitMQ();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();   
}

app.UseHttpsRedirection();
app.UseStaticFiles();

SeedData();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

void SeedData()
{
    Console.WriteLine("--> Seeding data");
    using(var scope = app.Services.CreateScope())
    {
        var dbInit = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInit.Initialize();
    }
}