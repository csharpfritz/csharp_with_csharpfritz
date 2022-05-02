using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Globalization features
builder.Services.AddLocalization();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseRequestLocalization(new RequestLocalizationOptions()
//     .AddSupportedCultures(new[] { "en-US", "es", "de-DE" })
//     .AddSupportedUICultures(new[] { "en-US", "es", "de-DE" }));

/* Configure supported cultures */
var supportedCultures = new[] { "en-US", "es", "de-DE" };
var localizationOptions = new RequestLocalizationOptions()
    // .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
