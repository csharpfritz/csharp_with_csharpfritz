using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormComponents
{

	public class FritzHat
	{

		[Required]
		public string Name { get; set; }

		[MaxLength(100, ErrorMessage = "That's too much detail my friend.  Get a little more direct in your description")]
		public string Description { get; set; }

		public bool NeedsWashing { get; set; }

		public string Genre { get; set; }

		[Range(2000, 2021)]
		public int YearAcquired { get; set; }


		public DateTime DateLastWorn { get; set; }

	}

}
