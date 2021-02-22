using Microsoft.AspNetCore.Authorization;

namespace WebApp1
{
		
	public static class MyPolicy {

		public static void ConfigurePolicy(AuthorizationOptions options) {

				options.AddPolicy("AdminOnly", policy => policy.RequireRole("Administrator"));
				options.AddPolicy("AmericanRegion", policy => 
					policy.RequireClaim("location", new string[] { "Philadelphia", "Boston", "Baltimore", "Atlanta"})
				);
				options.AddPolicy("BostonOnly", policy => 
					policy.RequireClaim("location", new string[] { "Philadelphia", "Boston" })
				);
				options.AddPolicy("CanadianRegion", policy => 
					policy.RequireClaim("location", new string[] { "Montreal", "Toronto", "Ottawa"})
				);
		}

	}

}