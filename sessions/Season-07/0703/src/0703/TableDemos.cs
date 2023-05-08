using System.Diagnostics;
using Azure;
using Azure.Data.Tables;

public static class TableDemos
{

	public static TableClient GetTableClient()
	{

		return new TableClient("UseDevelopmentStorage=true", "people");

		
	}

	public static void Demo()
	{

		var client = TableDemos.GetTableClient();
		client.CreateIfNotExists();

		var person = new Person() { Name = "CSharpfritz", Email = "jeff@csharpfritz.com" };
		client.AddEntity(person);

		var mrsCsharpfritz = new Person() { Name = "Mrs. CSharpfritz", Email = "mrs@csharpfritz.com" };
		client.AddEntity(mrsCsharpfritz);

		var scott = new Person() { Name = "Scott", Email = "scott@microsoft.com" };
		client.AddEntity(scott);


	}

	public static void DemoQueries()
	{

		var client = TableDemos.GetTableClient();

		var sw = Stopwatch.StartNew();
		var results = client.Query<Person>(p => p.PartitionKey == "csharpfritz.com");
		sw.Stop();
		System.Console.WriteLine($"Query took {sw.ElapsedMilliseconds} ms");

		foreach (var person in results)
		{
			System.Console.WriteLine(person.Name);
		}


	}


}

public class Person : ITableEntity {
	public string PartitionKey {get {return  Email.Split('@')[1]; } set {} }
	public string RowKey { get {return Email; } set {} }
	public string Name { get; set; }
	public string Email { get; set; }
	public DateTimeOffset? Timestamp { get; set;}
	public ETag ETag { get; set; }
}