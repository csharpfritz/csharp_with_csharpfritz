using Microsoft.EntityFrameworkCore;
using MyFirstApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(
    options =>
    {
        options.UseSqlite("Data Source=contacts.db");
    });

var app = builder.Build();
var ctx = app.Services.CreateScope().ServiceProvider.GetService<MyDbContext>();
ctx.Database.EnsureCreated();


app.MapGet("/", () => "Hello World!");
app.MapGet("/contacts", (MyDbContext ctx) => ctx.Contacts);

app.Run();
