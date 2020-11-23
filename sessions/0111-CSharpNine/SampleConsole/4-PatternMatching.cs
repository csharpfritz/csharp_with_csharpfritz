using static System.Console;

namespace SampleConsole
{

	public class PatternMatching
	{

		public static void Demo()
		{

			var pm = new PatternMatching();
			// pm.Basics();
			// pm.BasicSwitch();
			// pm.PropertyPattern();
			// WriteLine(pm.RockPaperScissors("rock", "paper"));
			//  pm.NineSimplePattern();
			// pm.NineRelationalPatterns();
			pm.NineLogicalPatterns();

		}

		public void Basics()
		{

			// Match on the SHAPE of an object
			object data = 1.1;

			if (data is int i) WriteLine($"That was an integer: {i}");
			else if (data is double d) WriteLine("Ooh, a double!");
			else WriteLine("Please give me a number");

		}

		public void BasicSwitch()
		{

			object data = 0;

			switch (data)
			{

				case 0:
					WriteLine("Zero");
					break;
				case float d:
					WriteLine("Double!");
					break;
				case int n when n > 0:
					WriteLine("A positive integer");
					break;
				case null:
					WriteLine("Give me a value!");
					break;
				default:
					WriteLine("You're boring...");
					break;
			}

		}

		public void PropertyPattern()
		{

			// Calculate toll
			Vehicle v = new Truck {Passengers=2};

			var toll = v switch
			{
				{ Wheels: 2 } => 0.25,
				{ Wheels: 4 } => 0.50,
				Truck t when t.TotalWeight < 10000 => 1.00,
				_ => 2.00
			};

			WriteLine("Toll assessed is: " + toll.ToString("c"));

		}

		public string RockPaperScissors(string first, string second)
		=> (first, second) switch
		{
			("rock", "paper")     => "rock is covered by paper. Paper wins.",
			("rock", "scissors")  => "rock breaks scissors. Rock wins.",
			("paper", "rock")     => "paper covers rock. Paper wins.",
			("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
			("scissors", "rock")  => "scissors is broken by rock. Rock wins.",
			("scissors", "paper") => "scissors cuts paper. Scissors wins.",
			(_, _)                => "tie"
		};


		public void NineSimplePattern() {

			// Calculate toll
			Vehicle v = new Car();

			var toll = v switch
			{
				{ Wheels: 2 } => 0.25,
				{ Wheels: 4 } => 0.50,
				Truck => 1.00,
				_ => 2.00
			};

			WriteLine($"Your toll is: {toll:c}");

			
		}

		public void NineRelationalPatterns() {

			// Calculate toll
			Truck t = new Truck { TotalWeight=9500 };

			var toll = t.TotalWeight switch
			{
				< 5000 => 1.00,
				< 10000 => 2.00,
				> 50000 => 5.00,
				_ => 3.00  
			};

			WriteLine($"Your toll is: {toll:c}");
			
		}

		public void NineLogicalPatterns() {

			// Calculate toll
			Truck t = new Truck { TotalWeight=9500 };

			// and or not 

			var toll = t.TotalWeight switch
			{
				< 5000 => 1.00,
				< 10000 and >= 5000 => 2.00,
				> 50000 => 5.00,
				_ => 3.00  
			};

			WriteLine($"Your toll is: {toll:c}");

		}

		#region Objects 

		public abstract class Vehicle
		{

			public int Passengers { get; set; }

			public int Wheels { get; set; }

		}

		public class Car : Vehicle
		{
			public Car()
			{
				Wheels = 4;
			}
		}

		public class Truck : Vehicle
		{
			public int TotalWeight { get; set; }
		}

		#endregion

	}

}
