# C# Eleven New Features

With .NET 7 there are a handful of new features to the C# language that will help you with simple and complex tasks.  In this module, we'll introduce some of these new features for you to explore.  The official [Microsoft documentation](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-11) has more detailed content for you.

## Generic Math Support

To this point, all Math operations with the C# language have been pre-defined and built into the langauge and .NET runtime for you.  If you need to extend and build math operations for your own types, it wasn't possible.  Several new language features and interfaces now enable you to define your own Math operations.

### static virtual and static abstract Members on Interfaces

You can now add method definitions to your interfaces and label them as `static virtual` or `static abstract` depending on whether they come with an implementation or not.  Let's look at the `System.IParsable<T>` interface:

```csharp
IParsable<T> where T : IParseable<T>
{
  static abstract T Parse(string s, IFormatProvider? provider);

  static abstract bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out T result);

}
```

These two methods must be implemented by your type too enable parsing of string content.

We can implement our own static method for an interface using the `static virtual` labels.  Let's revisit the playing cards sample and add an interface for playing cards:

```csharp
public interface IPlayingCard<T> where T : IPlayingCard<T>
{

	static virtual IEnumerable<T> Shuffle(IEnumerable<T> values)
	{

		return values.OrderBy(_ => Guid.NewGuid());

	}

}
```

With this interface, we can define playing cards for all types of games: Poker, Pinnochle, Pokemon, Magic the Gathering and all of the cards know how to shuffle when they implement this interface.

### C# 11 Numeraic Interfaces

These two language constructs allow you to define many different operators in your objects.  The runtime provides interfaces to support using those operators:

| Operator Interface Name | Summary |
| --- | --- |
| IParseable | Parse(string, IFormatProvider) |
| ISpanParseable | Parse(ReadOnlySpan<char>, IFormatProvider) |
|IAdditionOperators	| x + y |
| IBitwiseOperators	 | x & y, x \| y, x ^ y, and ~x 
| IComparisonOperators | x < y, x > y, x <= y, and x >= y |
| IDecrementOperators |	--x and x-- |
| IDivisionOperators | x / y |
| IEqualityOperators | x == y and x != y |
| IIncrementOperators |	++x and x++ |
| IModulusOperators | x % y |
| IMultiplyOperators | x * y |
| IShiftOperators |	x << y and x >> y |
| ISubtractionOperators | x - y |
| IUnaryNegationOperators | -x |
| IUnaryPlusOperators |	+x |
| IAdditiveIdentity |	(x + T.AdditiveIdentity) == x |
| IMinMaxValue | T.MinValue and T.MaxValue |
| IMultiplicativeIdentity |	(x * T.MultiplicativeIdentity) == x |
| IBinaryFloatingPoint | Members common to binary floating-point types |
| IBinaryInteger | Members common to binary integer types |
| IBinaryNumber	| Members common to binary number types |
| IFloatingPoint | Members common to floating-point types |
| INumber |	Members common to number types |
| ISignedNumber | Members common to signed number types |
| IUnsignedNumber |	Members common to unsigned number types |

More details on these interfaces and their features are available on the [.NET Blog](https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/).

## Raw String Literals

Formatting strings with C# can be tricky and difficult when you need to format content containing quotes and braces.  [Raw-String Literals](https://learn.microsoft.com/dotnet/csharp/language-reference/proposals/csharp-11.0/raw-string-literal) introduces the new triple quote `"""` syntax allows you to format content and forget about newlines, escaping characters, and indents.

```csharp
string longMessage = """
    This is a long message.
    It has several lines.
        Some are indented
                more than others.
    Some should start at the first column.
    Some have "quoted text" in them.
    """;
```

Multi-line expressions should start their content at the same indent level as their closing quotes.  Anything indented past that column will be indented in the output.

Formats like XML and JSON are much more readable with this formatting:

```csharp
var name = "fritz";
string embeddedXML = $"""
       <element attr = "content">
           <body style="normal">
               Here is {name}'s content
           </body>
           <footer>
               Excerpts from "An amazing story"
           </footer>
       </element >
       """;
```

If you need to place double-quotes `""` inside the block or output curly-braces `{}` you can simply add more quotes or dollar signs to the beginning of the string to indicate the number of quotes or braces necessary to close the string. Anything smaller is ignored.

```csharp
double Latitude = 0.0d, Longitude = 0.0d;

var location = $$"""
   You are at {{{Latitude}}, {{Longitude}}}
   """;
```

## List Pattern Matching

Pattern matching is a powerful feature of the C# language that allows you to test properties and values between objects.  With [List Pattern matching](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/patterns#list-patterns), you can test against the contents of a collection.

Let's look at our playing card sample again.  We can add a method for standard poker playing cards to test if we are holding a straight in five-card poker.  You could write some code to test and return a boolean indicating if you have a straight like this:

```csharp
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
```

That works, but is very math-centric and takes a bit of thinking to comprehend.  Additionally, what about the high-straight (10, J, Q, K, A) and the low-straight (A, 2, 3, 4, 5)?  

Let's re-write it with a pattern match:

```csharp
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
```

That's a LOT more readable and we've included a pattern at the end for the high-straight.

## Required Keyword

The [`required` keyword](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/required) allows you to indicate fields and properties that are required to be initialized by all constuctors or when using object initializer syntax.  Let's take a look at our `PokerPlayingCard` type and the `Rank` field.

```csharp
private int Rank;

public PokerPlayingCard(int rank)
{
    Rank = rank;
}
```

Here, the `Rank` field is marked private so that it must be assigned in the constructor.  If we would like to allow it to be set with an initializer, we could use the require keyword and make the field public. 

```csharp
public class PokerPlayingCard {
    public required int Rank;
    public PokerPlayingCard() {}
}

var Ace = new PokerPlayingCard { Rank = 1 };
```

Declaring the variable `Ace` without assigning a rank would generate a compiler error.

## File-Scoped Types

The `file` keyword can be used to constrain access to a top-level type to within the file in which it is declared.  This interaction is expected to apply to generated code or unit test.

Let's look at configuring some tests:

```csharp
// Tests.cs
file class Configure
{

    public void DoConfiguration() {}

}

public class TestFixture {

    [Fact]
    public void TestOne()
    {

        // arrange
        var config = new Configure();
        config.DoConfiguration();

    }

}

```

In another file, the type `Configure` could also be defined as `internal` or `public` and its use will be available to all other files in the project and the `TestFixture` class will prefer the file scoped `Configure` class.