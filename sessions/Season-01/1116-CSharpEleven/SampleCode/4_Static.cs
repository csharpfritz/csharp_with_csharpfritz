using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEleven;

public interface IPlayingCard<T> where T : IPlayingCard<T>
{

	static abstract T operator ++(T value);

	static virtual IEnumerable<T> Shuffle(IEnumerable<T> values)
	{

		return values.OrderBy(_ => Guid.NewGuid());

	}

}

public partial class PokerPlayingCard : IPlayingCard<PokerPlayingCard>
{

	public static readonly PokerPlayingCard Ace = new PokerPlayingCard(1);
	public static readonly PokerPlayingCard Two = new PokerPlayingCard(2);
	public static readonly PokerPlayingCard Three = new PokerPlayingCard(3);
	public static readonly PokerPlayingCard Four = new PokerPlayingCard(4);
	public static readonly PokerPlayingCard Five = new PokerPlayingCard(5);
	public static readonly PokerPlayingCard Six = new PokerPlayingCard(6);
	public static readonly PokerPlayingCard Seven = new PokerPlayingCard(7);
	public static readonly PokerPlayingCard Eight = new PokerPlayingCard(8);
	public static readonly PokerPlayingCard Nine = new PokerPlayingCard(9);
	public static readonly PokerPlayingCard Ten = new PokerPlayingCard(10);
	public static readonly PokerPlayingCard Jack = new PokerPlayingCard(11);
	public static readonly PokerPlayingCard Queen = new PokerPlayingCard(12);
	public static readonly PokerPlayingCard King = new PokerPlayingCard(13);

	public static readonly PokerPlayingCard[] All = new[]
	{
		Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
	};

	public static PokerPlayingCard operator ++(PokerPlayingCard value)
	{
		return All[(value.Rank + 1) % All.Length];
	}

	public static PokerPlayingCard operator --(PokerPlayingCard value)
	{
		return All[(value.Rank - 1) % All.Length];
	}

	public static bool operator ==(PokerPlayingCard left, PokerPlayingCard right)
	{
		return left.Rank == right.Rank;
	}

	public static bool operator !=(PokerPlayingCard left, PokerPlayingCard right)
	{
		return left.Rank != right.Rank;
	}

	public static bool operator >(PokerPlayingCard left, PokerPlayingCard right)
	{
		return left.Rank > right.Rank;
	}

	public static bool operator <(PokerPlayingCard left, PokerPlayingCard right)
	{
		return left.Rank < right.Rank;
	}

	public static bool operator >=(PokerPlayingCard left, PokerPlayingCard right)
	{
		return left.Rank >= right.Rank;
	}

	public static bool operator <=(PokerPlayingCard left, PokerPlayingCard right)
	{
		return left.Rank <= right.Rank;
	}

	private static readonly string[] Ranks = new string[]
	{
		"Ace",
		"Two",
		"Three",
		"Four",
		"Five",
		"Six",
		"Seven",
		"Eight",
		"Nine",
		"Ten",
		"Jack",
		"Queen",
		"King"
	};

	private int Rank;
	
	public PokerPlayingCard(int rank)
	{
		Rank = rank;
	}

	public override string ToString()
	{
		return Ranks[Rank - 1];
	}

}
