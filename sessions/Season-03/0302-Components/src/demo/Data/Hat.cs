using System.Collections.Generic;

namespace demo.Data {

	public class Hat {

		public string Name { get; set; }

		public string Theme { get; set; }

		public int Year { get; set; }

		public static readonly Hat[] Collection = new Hat[] {

			new Hat { Name="Camp Crystal Lake", Year=2020, Theme="Movies" },
			new Hat { Name="Marauder's Map", Year=2020, Theme="Movies" },
			new Hat { Name="Super C#", Year=2018, Theme="Tech" },
			new Hat { Name="Dunder Mifflin", Year=2018, Theme="TV" },
			new Hat { Name="Space X", Year=2019, Theme="Tech" },
			new Hat { Name="Phillies 2008 World Series", Year=2008, Theme="Sports" },
			new Hat { Name="The Flash", Year=2021, Theme="TV" }

		};

	}

	public class HatRepository {

		private static readonly Hat[] Collection = new Hat[] {

			new Hat { Name="Camp Crystal Lake", Year=2020, Theme="Movies" },
			new Hat { Name="Marauder's Map", Year=2020, Theme="Movies" },
			new Hat { Name="Super C#", Year=2018, Theme="Tech" },
			new Hat { Name="Dunder Mifflin", Year=2018, Theme="TV" },
			new Hat { Name="Space X", Year=2019, Theme="Tech" },
			new Hat { Name="Phillies 2008 World Series", Year=2008, Theme="Sports" },
			new Hat { Name="The Flash", Year=2021, Theme="TV" }

		};

		public IEnumerable<Hat> Get() {
			return Collection;
		}
		
	}

}