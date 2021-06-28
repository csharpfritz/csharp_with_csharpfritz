using System;

namespace sample
{

// #nullable enable 

  public static class ReferenceTypes {

    public static void SimpleNull() {

      Hat myHat = new Hat();

      Console.WriteLine($"MyHat is a: {myHat.GetType().Name} and {myHat}");

    }

    public static void Property() {

      var myHat = new Hat();

      Console.WriteLine($"MyHat's name is {myHat.AcquiredYear.GetType().Name}: {myHat.AcquiredYear.ToString()}");

    }

    public static void NullForgiving() {

      var myHat = Find();

      Console.WriteLine($"myHat is named {myHat!.Name}");

    }

    private static Hat Find() {
      return new Hat();
    }

  }

// #nullable restore

}