using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OfficialProject3.Data;
using OfficialProject3.Hubs;
using OfficialProject3.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
/*builder.Services.AddRazorPages(options =>
{
    string[] authorizePages = {"/Privacy"};
    string[] authorizeFolders = {};
    foreach (var page in authorizePages)
        options.Conventions.AuthorizePage(page);
    foreach (var page in authorizeFolders)
        options.Conventions.AuthorizeFolder(page);
}    
); */

/*builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
}); */

builder.Services.AddSignalR();

builder.Services.Configure<IdentityOptions>(options =>
{
    //Account settings
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = true;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

/*app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/"
); */

app.MapRazorPages();

app.MapHub<UserOnlineHub>("/GetUserOnline");
app.Run();
