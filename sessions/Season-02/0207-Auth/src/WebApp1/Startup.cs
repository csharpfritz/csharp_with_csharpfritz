using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp1.Areas.Identity.Data;
using System.Security.Claims;

namespace WebApp1
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
					options.UseSqlite(
							Configuration.GetConnectionString("DefaultConnection")));
			services.AddDatabaseDeveloperPageExceptionFilter();
			services.AddDefaultIdentity<WebApp1.Areas.Identity.Data.WebApp1User>()
				.AddRoles<IdentityRole>()
					.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddAuthentication()
				.AddGitHub(config => {
					config.ClientId = "SOMETHING";
					config.ClientSecret = "ELSE";
				})
				.AddGoogle(config => {
					config.ClientId = "SOMETHING";
					config.ClientSecret = "ELSE";
				})
				.AddTwitch(config => {
					config.ClientId = "SOMETHING";
					config.ClientSecret = "ELSE";
				});

			services.AddAuthorization(WebApp1.MyPolicy.ConfigurePolicy);

			services.AddRazorPages(options => {

				options.Conventions.AuthorizePage("/Secret", "AmericanRegion");

			});

			services.Configure<IdentityOptions>(options =>
			{

				// Password settings.
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;

				// Lockout settings.
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;

				// User settings.
				options.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = false;

			});

			services.ConfigureApplicationCookie(options =>
				{
					options.AccessDeniedPath = "/Identity/Account/AccessDenied";
					options.Cookie.Name = "YourAppCookieName";
					options.Cookie.HttpOnly = true;
					options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
					options.LoginPath = "/Identity/Account/Login";
					options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
					options.SlidingExpiration = true;
				});

			ConfigureRoles(services.BuildServiceProvider()).GetAwaiter().GetResult();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
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

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});

		}

		private async Task ConfigureRoles(ServiceProvider serviceProvider)
		{

			var roleMgr = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var exists = await roleMgr.RoleExistsAsync("Administrator");
			if (!exists)
			{
				var admin = new IdentityRole
				{
					Name = "Administrator"
				};
				await roleMgr.CreateAsync(admin);
			}

			var adminRole = await roleMgr.FindByNameAsync("Administrator");
			var userMgr = serviceProvider.GetRequiredService<UserManager<WebApp1User>>();
			var user = await userMgr.FindByEmailAsync("jeff@jeffreyfritz.com");

			if (user != null)
			{

				var isAdmin = await userMgr.IsInRoleAsync(user, "Administrator");
				if (!isAdmin)
				{
					await userMgr.AddToRoleAsync(user, "Administrator");
				}

				var claims = await userMgr.GetClaimsAsync(user);
				if (!claims.Any(c => c.Type == "location"))
				{
					var locationClaim = new Claim("location", "Philadelphia");
					await userMgr.AddClaimAsync(user, locationClaim);
				}

			}

		}
	}
}
