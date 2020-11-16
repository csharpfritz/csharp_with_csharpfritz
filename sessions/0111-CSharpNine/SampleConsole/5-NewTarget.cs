using System;
using System.Drawing;
using System.Collections.Generic;
using static System.Console;

namespace SampleConsole {

  public class NewTarget {

    public static void Demo() {

      var t = new NewTarget();
      t.Demo1();

    }

    public void Demo1() {

      List<int> myList = new();      

      // Repeated object initializers
      Point[] numbers = {new (1,1), new(1,2), new(1,3)};
      WriteLine(numbers.Length);

    }

  }

}