using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.MinimalAPI.Server.Data;
using Services.MinimalAPI.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add database to the container.
builder.Services
	.AddSqlite<MyContext>(
		builder.Configuration
		.GetConnectionString("Sqlite")
	);

#region ASP.NET Configuration

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();

app.Services.CreateScope().ServiceProvider
	.GetRequiredService<MyContext>()
	.Database.EnsureCreated();

#region HTTP Configuration
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

#endregion

#region Minimal APIs for Contacts
/* 
app.MapGet("/api/Contacts", async (MyContext db) =>
{
	return Results.Ok(await db.Contacts.Select(c => c.AsViewModel()).ToArrayAsync());
});

app.MapGet("/api/Contacts/{id:int}", async (MyContext db, [FromRoute] int id) =>
{
	var contact = await db.Contacts.SingleOrDefaultAsync(x => x.Id == id);
	if (contact is null) return Results.NotFound();
	return Results.Ok(contact.AsViewModel());
});

app.MapPost("/api/Contacts", async (MyContext db, [FromBody] Contact newContact) =>
{
	newContact.Id = 0;
	await db.Contacts.AddAsync(newContact);
	await db.SaveChangesAsync();
	return Results.Created($"/api/Contacts/{newContact.Id}", newContact);
});

app.MapPut("/api/Contacts/{id:int}", async (MyContext db, [FromRoute] int id, [FromBody] Contact newContact) =>
{

	var theContact = await db.FindAsync<Contact>(id);
	if (theContact is null) return Results.NotFound();

	theContact.Name = newContact.Name;
	theContact.EmailAddress = newContact.EmailAddress;

	await db.SaveChangesAsync();
	return Results.NoContent();

});

app.MapDelete("/api/Contacts/{id:int}", async (MyContext db, [FromRoute] int id) =>
{

	if (await db.Contacts.FindAsync(id) is Contact contact)
	{
		db.Contacts.Remove(contact);
		await db.SaveChangesAsync();
		return Results.Ok();
	}

	return Results.NotFound();

});
 */
#endregion


app.MapInstantAPIs<MyContext>(config =>
{
	config.IncludeTable(db => db.Contacts,
		Fritz.InstantAPIs.ApiMethodsToGenerate.Get |
		Fritz.InstantAPIs.ApiMethodsToGenerate.GetById);
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint(
		"/swagger/v1/swagger.json", 
		"My API v1"
	);
});

app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.Run();
