using static System.Console;

namespace CSharpEleven;

internal class ListPattern
{

  public static int CheckSwitch(int[] values)
      => values switch
      {
        [1, 2, .., 10] => 1,
        [1, 2] => 2,
        [1, _] => 3,
        [1, ..] => 4,
        [..] => 50
      };

  public static void Test()
  {

    WriteLine(CheckSwitch(new[] { 1, 2, 10 }));          // prints 1
    WriteLine(CheckSwitch(new[] { 1, 2, 7, 3, 3, 10 })); // prints 1
    WriteLine(CheckSwitch(new[] { 1, 2 }));              // prints 2
    WriteLine(CheckSwitch(new[] { 1, 3 }));              // prints 3
    WriteLine(CheckSwitch(new[] { 1, 3, 5 }));           // prints 4
    WriteLine(CheckSwitch(new[] { 2, 5, 6, 7 }));        // prints 50
    
  }
  
}
