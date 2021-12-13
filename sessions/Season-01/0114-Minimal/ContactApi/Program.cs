using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MyDbContext>(options => {
    options.UseSqlite("Data Source=contacts.db");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "Contacts API",
         Description = "Storing and sharing contacts for my DEVintersection friends",
         Version = "v1" });
});

var app = builder.Build();

var ctx = app.Services.CreateScope().ServiceProvider.GetService<MyDbContext>();
ctx.Database.EnsureCreated();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGet("/contacts", (MyDbContext ctx) => ctx.Contacts);
app.MapGet("/contacts/{id:int}", (MyDbContext ctx, int id) => ctx.Contacts.Find(id));
app.MapPost("/contacts", async (MyDbContext ctx, Contact newContact) => {
    await ctx.Contacts.AddAsync(newContact);
    await ctx.SaveChangesAsync();
    return Results.Created($"/contacts/{newContact.Id}", newContact);
}).Produces<Contact>(StatusCodes.Status201Created);
app.MapPut("/contacts/{id:int}", async (MyDbContext ctx, Contact updateContact, int id) =>
{
    var contact = await ctx.Contacts.FindAsync(id);
    if (contact is null) return Results.NotFound();
    ctx.Contacts.Attach(updateContact);
    await ctx.SaveChangesAsync();
    return Results.NoContent();
}).Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status204NoContent);
app.MapDelete("/contacts/{id:int}", async (MyDbContext ctx, int id) =>
{
    var contact = await ctx.Contacts.FindAsync(id);
    if (contact is null) return Results.NotFound();
    ctx.Contacts.Remove(contact);
    await ctx.SaveChangesAsync();
    return Results.NoContent();
}).Produces(StatusCodes.Status204NoContent);

app.Run();

public record class Contact {
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
}

public class MyDbContext : DbContext
{

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}

    public DbSet<Contact> Contacts { get; set; }   
}