using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEleven;


internal class Foo : IParsable<Foo>
{
  public static Foo Parse(string s, IFormatProvider? provider)
  {
    throw new NotImplementedException();
  }

  public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Foo result)
  {
    throw new NotImplementedException();
  }
}

internal class Person : IComparable<Person>
{

  public Person(int age, string name)
  {

    this.Age = age;
    this.Name = name;

  }

  public int Age { get; }
  public string Name { get; }

  public int CompareTo(Person? other)
  {

    if (other == null) return 0;

    return other.Age > this.Age ? -1 : 1;

  }
}