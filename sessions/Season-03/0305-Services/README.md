# Session 0305 : Using Blazor with Services and Databases

When Blazor runs on a server, its pretty easy to connect and work with databases and other web services.  We already know how to do this with ASP.NET Core applications, and the technique is the same.  Inject a service that connects to that database or give us an `HttpClient` that we can use to interact with the service.

What about Blazor Web Assembly?  How do we connect to databases and services when the application runs in the browser?  We connect to databases and services the same way that JavaScript developers do: using web services.

## ASP.NET Core API with Controllers

Check out the standard Controller-based interactions with a server in the [Services Folder](https://github.com/csharpfritz/csharp_with_csharpfritz/tree/main/sessions/Season-03/0305-Services/src/Services)  This model uses a Shared project that contains shared C# objects that are used both on the Server and the Client.  

The Server contains a [Controller](https://github.com/csharpfritz/csharp_with_csharpfritz/blob/main/sessions/Season-03/0305-Services/src/Services/Server/Controllers/WeatherForecastController.cs) that delivers a faux weather forecast called `WeatherForecastController` when an HTTP GET is executed against the `/Weatherforecast` route on the server.

The Client has a page called [FetchData](https://github.com/csharpfritz/csharp_with_csharpfritz/blob/main/sessions/Season-03/0305-Services/src/Services/Client/Pages/FetchData.razor) that retrieves that weather forecast and displays it on the page.  Note the key parts of the Blazor code that inject the HttpClient and then use that client to get data:

```razor
@inject HttpClient Http
...
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
    }
```

The `WeatherForecast` object from the Shared project is reused and the data from the `/weatherforecast` address is fetched, deserialized into an array of `WeatherForecast` .NET objects that is then painted on the page.

## OpenAPI

We can add OpenAPI bindings, which deliver a service definition that allow us to construct clients that adhere strictly to the service definition.  In the [Services.OpenAPI](https://github.com/csharpfritz/csharp_with_csharpfritz/tree/main/sessions/Season-03/0305-Services/src/Services.OpenAPI) project you will find the same Client, Server, and Shared projects but this time the server has had the [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/) package installed to facilitate the creation of the OpenAPI service definition.

The service definition is added to the services collection and then added to the HTTP pipeline in the `ConfigureServices` and `Configure` methods in Startup.  In .NET 6 projects, these statements may all reside in the same `Program.cs` file.

```csharp
	public void ConfigureServices(IServiceCollection services)
	{

		services.AddControllersWithViews();
		services.AddRazorPages();

		services.AddSwaggerGen();

	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{

		...
		app.UseBlazorFrameworkFiles();
		app.UseStaticFiles();

		app.UseSwaggerUI(c =>
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
		});

		app.UseRouting();
		...

	}
```

You can then add a reference to the OpenAPI definition in the client project with a right-click gesture in Visual Studio, choosing to add a Service Reference.

If you're not using Visual Studio, you can use a similar command at the command-line using the `Microsoft.dotnet-openapi` tool.  Instructions for installing and using that tool are on the [official Microsoft docs site](https://docs.microsoft.com/aspnet/core/web-api/Microsoft.dotnet-openapi).

## SignalR

SignalR is the ASP.NET technology for allowing two-way communication between clients and web servers.  You may already be familiar with Web Sockets, and SignalR provides access to that technology as well as fall-back technologies to ensure clients connected.

Demos for this sample are in the [SignalR folder](https://github.com/csharpfritz/csharp_with_csharpfritz/tree/main/sessions/Season-03/0305-Services/src/SignalR).

## Minimal API and Database connections

Minimal APIs are the new and more concise way to build services for your application.  In the demos in the [Services.MinimalAPI folder](https://github.com/csharpfritz/csharp_with_csharpfritz/tree/main/sessions/Season-03/0305-Services/src/Services.MinimalAPI) we'll connect some minimal APIs to a SQLite database using Entity Framework Core.