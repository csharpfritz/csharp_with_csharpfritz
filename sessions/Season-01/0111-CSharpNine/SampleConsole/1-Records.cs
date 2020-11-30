using System;
using static System.Console;

namespace SampleConsole
{

	public class Records
	{

		public static void Demo()
		{

			// Create a record object and inspect its string and equals
			//Demo1();

			// Inheritance with records
			// Demo2();

			// Deconstruction and Cloning
			//Demo3();

		}

		#region Demo 1

		public static void Demo1()
		{

			// Create a new record object and inspect its string
			var p = new Person("jeff", "fritz");
			// WriteLine(p.FirstName);

			//WriteLine(new PersonClass("jeff","fritz"));

			// Change the record object
			//p.LastName = "smith";

			// second record equals first
			var s = new Person("jeff", "fritz");
			WriteLine( p == s);

		}

		public class PersonClass {
			public string FirstName { get; set; }
			public string LastName { get; set; }

			public override string ToString()
			{
				return $"{FirstName} {LastName}";
			}

			public PersonClass(string first, string last) =>
			(FirstName, LastName) = (first, last);

		}

		public record Person
		{

			public string FirstName { get; }
			public string LastName { get; }

			public Person(string first, string last) =>
						(FirstName, LastName) = (first, last);

		}

		#endregion

		#region Demo 2

		public static void Demo2()
		{

			// Records support inheritance

			// var p = new CoolPerson("jeff", "fritz");
			// WriteLine(p);

			var r = new Rockstar("Freddie", "Mercury", "Queen");
			// WriteLine(r);

			WriteLine(r as CoolPerson);

		}

		public record CoolPerson(string FirstName, string LastName);

		public record Rockstar(string FirstName, string LastName, string BandName) : CoolPerson(FirstName, LastName);

		#endregion

		#region Demo 3

		public static void Demo3() {

			var p = new CoolPerson("jeff", "fritz");
			var (first, last) = p;

			WriteLine($"First: {first} Last: {last}");

			// Clone using the WITH expression
			var s = p with { FirstName="scott" };
			WriteLine(s);
			WriteLine(p);

		}

		#endregion

	}

}