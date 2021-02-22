// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.AspNetCore;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Http;

// await WebHost.CreateDefaultBuilder(args)
// 	.Configure(app => {
// 		app.UseRouting();
// 		app.UseEndpoints(e => {
// 			e.MapGet("/", ctx => {
// 					ctx.Response.ContentType = "application/json";
// 					return ctx.Response.WriteAsJsonAsync(new {Hello= "From Routes"});
// 			});
// 			e.MapGet("{name}", ctx => {
// 				if (!Data.Contacts.Any<Person>(c => c.First.Equals(ctx.Request.RouteValues["name"].ToString(), StringComparison.InvariantCultureIgnoreCase))) {
// 					ctx.Response.StatusCode = 404;
// 					return ctx.Response.CompleteAsync();
// 				} else {
// 					ctx.Response.ContentType = "application/json";
// 					return ctx.Response.WriteAsJsonAsync(Data.Contacts.First(c =>c.First.Equals(ctx.Request.RouteValues["name"].ToString(), StringComparison.InvariantCultureIgnoreCase)));
// 				}
// 			});
// 		});
// 	}).Build().RunAsync();


// public record Person(string First, string Last);

// public class Data {
// 	public static readonly List<Person> Contacts = new List<Person> {
// 		new Person("Jeff", "Fritz"),
// 		new Person("Mary", "Contrary"),
// 		new Person("Joe","Bag O'Donuts")
// 	};

// }
