using Serilog;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MyCollectionSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyCollectionSiteIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MyCollectionSiteIdentityDbContextConnection' not found.");

builder.Host.UseSerilog((context, services, configuration) => configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext()
                    .WriteTo.Console());

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddDbContext<CollectionContext>(
    options => options.UseSqlite("Data Source=MyCollectionSite.db")
);

builder.Services.AddDefaultIdentity<IdentityUser>(
	options => {
		options.SignIn.RequireConfirmedAccount = true;
	})
    .AddEntityFrameworkStores<CollectionContext>();

// builder.Services.ConfigureApplicationCookie(options => {
// 			options.Cookie.Name = "CollectionSite";
// 			options.Cookie.IsEssential = true;
// 			options.Cookie.HttpOnly = true;
// 			options.LoginPath = "/Identity/Account/Login";
// 			options.LogoutPath = "/Identity/Account/Logout";
// 			options.AccessDeniedPath = "/Identity/Account/AccessDenied";
// 			options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
// 		});
// builder.Services.AddAuthorization();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseSwagger();
app.UseSwaggerUI();
    
app.Use(async (context, next) =>
{

    context.Request.Headers["X-Requested-With"] = "XMLHttpRequest";

    var error = context.Features.Get<IExceptionHandlerFeature>();
    if (error != null)
    {
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(error.Error, error.Error.Message);
    }
    await next();
}
);

app.MapHub<MyCollectionSite.VotingHub>("/voting");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
