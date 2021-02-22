# Session 11 - New C# v9 Features

With the new release of .NET 5 in November 2020, a new version of the C# programming language was shipped labeled C# v9.  Let's take a look at five of the largest updates to the language in this session:

1. Record data types
1. Init Only Setters
1. Top Level Programs
1. Pattern Matching Enhancements
1. Target-Typed New Expressions

[Official Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9?WT.mc_id=visualstudio-twitch-jefritz) of these updates are available online.

## Record Data Types

Records are a new reference type that synthesizes methods to provide semantics for equality.  Records are immutable (cannot be modified) by default.

The compiler will generate the following methods for you in a record type:

- Methods for value-based equality comparisons
- GetHashCode()
- Copy and Clone members
- `PrintMembers` and `ToString()`

Take a look at the samples in `1-Records.cs` to interact with the `record` keyword and types.

## Init Only Setters

Classes can contain fields marked `readonly` that allow their values to only be set through a constructor.  This can be a bit limiting if you'd like to be able to set values through an intializer in the format:

```csharp
public class Person {
    public readonly string FirstName;
}

var p = new Person {
    FirstName = "Jeff"
};
```

That doesn't work...   neither does this:

```csharp
public class Person {
    public string FirstName { get; private set; }
}

var p = new Person {
    FirstName = "Jeff"
};
```

We can now introduce the `init` scope modifier for a property that allows is to only be set in a constructor OR an initializer.

```csharp
public class Person {
    public string FirstName { get; init set; }
}

var p = new Person {
    FirstName = "Jeff"
};
```

Try out the initializers in `2-Init.cs`

## Top Level Programs

You can now place a file in your project with statements not enclosed in a namespace, a class, or a method.  This can help with not just learning, but running methods quickly in a rapid-development scenario.

```csharp
System.Console.WriteLine("Hello World");
```

```dotnetcli
dotnet watch run
```

You can reach directly into your application and execute methods on classes.  When you're done testing and tinkering, you can remove the top-level file and everything will continue running with a normal `public static void Main` signature.

## Pattern Matching Enhancements

Pattern matching was a comparison technique introduced in C# 7 that allows you to test the _SHAPE_ of an object in an `if` or `switch` statement.

MORE DOCS ABOUT PATTERN-MATCHING FEATURES
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7?WT.mc_id=visualstudio-twitch-jefritz#pattern-matching


https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8?WT.mc_id=visualstudio-twitch-jefritz#more-patterns-in-more-places


## Target-Typed New Expressions

Constructors can now be simplified when the type is known to just a `new()` statement.

Check the samples in `5-NewTarget.cs`

