using System;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var w = new Weather("https://localhost:5001", new System.Net.Http.HttpClient());
			var forecasts = await w.WeatherForecastAsync();

			foreach (var item in forecasts)
			{
				Console.WriteLine($"Forecast on {item.Date}: {item.Summary} {item.TemperatureF}");
			}

		}
	}
}
