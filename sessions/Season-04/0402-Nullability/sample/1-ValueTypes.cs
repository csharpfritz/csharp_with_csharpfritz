using System;

namespace sample {

  public class ValueTypes {

    public static void Defaults() {

            int? i = null; //default(int);

      Console.WriteLine($"Default {i?.GetType().Name}: {i + 100}");

    }

    public static void Arrays() {

      var values = new string[3];
      string firstValue = values[0];
      Console.WriteLine(firstValue.ToLower());

    }

  }

}