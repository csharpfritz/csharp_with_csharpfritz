using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEleven;

public partial class PokerPlayingCard : IComparable<PokerPlayingCard>
{

	public static bool IsStraight(IEnumerable<PokerPlayingCard> values)
	{

		var ordered = values.OrderBy(v => v.Rank).ToArray();

		for (int i = 0; i < ordered.Length - 1; i++)
		{

			if (ordered[i + 1].Rank - ordered[i].Rank != 1)
			{

				return false;

			}

		}

		return true;

	}

	public static bool IsStraight_PatternMatching(IEnumerable<PokerPlayingCard> values)
	{

		var ordered = values.OrderBy(v => v.Rank).Select(v => v.Rank).ToArray();

		return ordered switch
		{
			[1, 2, 3, 4, 5] => true,
			[2, 3, 4, 5, 6] => true,
			[3, 4, 5, 6, 7] => true,
			[4, 5, 6, 7, 8] => true,
			[5, 6, 7, 8, 9] => true,
			[6, 7, 8, 9, 10] => true,
			[7, 8, 9, 10, 11] => true,
			[8, 9, 10, 11, 12] => true,
			[9, 10, 11, 12, 13] => true,
			[1, 10, 11, 12, 13] => true,
			_ => false
		};

	}


	public int CompareTo(PokerPlayingCard? other)
	{

		if (other == null) return 0;

		return other.Rank > this.Rank ? -1 : 1;
	}
}
