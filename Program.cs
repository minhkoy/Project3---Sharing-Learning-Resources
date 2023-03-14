using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficialProject3.Data;
using OfficialProject3.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(
    options => options.SignIn.RequireConfirmedAccount = true
    )
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

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Admin", "AdminPolicy");
    
});

builder.Services.AddSignalR();

builder.Services.Configure<IdentityOptions>(options =>
{
    //Account settings
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
    
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

var comments = app.MapGroup("/comments");
comments.MapGet("/", async (ApplicationDbContext context) =>
{
    return await context.Comment.ToListAsync();
    //return context.Comment;
});

comments.MapGet("/{id}", async (string id, ApplicationDbContext context) =>
{
    var comment = await context.Comment.FindAsync(id);
    if (comment == null) return Results.NotFound();
    else return Results.Ok(comment);
});

comments.MapPost("/", async (Comment comment, ApplicationDbContext context) =>
{
    context.Comment.Add(comment);
    await context.SaveChangesAsync();
    return Results.Created($"/comments/{comment.Id}", comment);
});

comments.MapGet("/upvote", async (string id, ApplicationDbContext context) =>
{
    var comment = await context.Comment.FindAsync(id);
    if (comment == null) return Results.NotFound();
    comment.Upvote++;
    await context.SaveChangesAsync();
    return Results.Ok(comment);
});

comments.MapGet("/downvote", async (string id, ApplicationDbContext context) =>
{
    var comment = await context.Comment.FindAsync(id);
    if (comment == null) return Results.NotFound();
    comment.Downvote++;
    await context.SaveChangesAsync();
    return Results.Ok(comment);
});

//comments.MapDelete("/{id}", async (ApplicationDbContext db, int id) =>
//{
//    //var comment = await db.Comment.FindAsync(id);
//    db.Remove(id);
//    await db.SaveChangesAsync();
//    return Results.Ok();
//});

///*var reports = app.MapGroup("/reports");
//reports.MapGet("/", async (ApplicationDbContext context) =>
//    {
//        //return await
//    }
//);*/

//var reports = app.MapGroup("/reports");

//reports.MapGet("/", async (ApplicationDbContext db) =>
//{
//    return await db.Report.ToListAsync();
//});

//reports.MapGet("/{id}", async (int id, ApplicationDbContext db) =>
//{
//    var report = await db.Report.FindAsync(id);
//    if (report == null) return Results.NotFound();
//    else return Results.Ok(report);
//});

//reports.MapPost("/", [IgnoreAntiforgeryToken(Order = 2000)] async ([FromBody] Report r, ApplicationDbContext db) =>
//{
//    await db.Report.AddAsync(r);
//    await db.SaveChangesAsync();
//    return Results.Ok(r);
//});

app.MapRazorPages();

app.MapHub<UserOnlineHub>("/GetUserOnline");
app.Run();
