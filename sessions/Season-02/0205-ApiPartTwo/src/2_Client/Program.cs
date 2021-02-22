using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _2_Client
{
	class Program
	{
		static async Task Main(string[] args)
		{

			var http = new HttpClient();

			var client = new swaggerClient("https://localhost:5001", http);
			var contacts = await client.ContactAllAsync();

			foreach (var c in contacts)
			{
				Console.WriteLine($"{c.FirstName} {c.LastName}");
			}

		}
	}
}
