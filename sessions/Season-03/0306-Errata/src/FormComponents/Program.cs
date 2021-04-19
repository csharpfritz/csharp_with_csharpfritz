using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazored.LocalStorage;
using Microsoft.JSInterop;
using System.Globalization;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace FormComponents
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddBlazoredLocalStorage();
			builder.Services.AddI18nText();

			var host = builder.Build();

			await AddLocalization(host);

			await host.RunAsync();

		}

		private static async Task AddLocalization(WebAssemblyHost host)
		{

			var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
			var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
			if (result != null)
			{
				Console.WriteLine($"Setting culture to {result}");
				var culture = new CultureInfo(result);
				CultureInfo.DefaultThreadCurrentCulture = culture;
				CultureInfo.DefaultThreadCurrentUICulture = culture;
			}

			// Set the current language
			var i18nText = host.Services.GetRequiredService<Toolbelt.Blazor.I18nText.I18nText>();
			await i18nText.SetCurrentLanguageAsync(result);

		}
	}
}
