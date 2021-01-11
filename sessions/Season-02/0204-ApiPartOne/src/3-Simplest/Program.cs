using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

await WebHost.CreateDefaultBuilder(args)
	.Configure(app => {
		app.Run(async c => {
			c.Response.ContentType = "application/json";
			await c.Response.WriteAsync("{\"hello\": \"from c# 9\"}");
		});
	}).Build().RunAsync();