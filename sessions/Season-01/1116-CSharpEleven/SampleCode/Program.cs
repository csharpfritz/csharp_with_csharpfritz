using CSharpEleven;
using System.Runtime.InteropServices;

//var people = new Person[]
//{
//  new Person(29,"Jeff"),
//  new Person(52, "Bill"),
//  new Person(32, "Maddy")
//};

//foreach (var p in people.Order())
//{
//    Console.WriteLine($"{p.Name} is {p.Age} years old");
//}


#region Raw String Literals

// Starts with three " on a single line,
// ends with three " on a single line.
// Newlines following opening and preceding ending are ignored.


string longMessage = """
  This is a long message.
  It has several lines.
      Some are indented
              more than others.
  Some should start at the first column.
  Some have "quoted text" in them.
  """;

//Console.WriteLine(longMessage);

// Whitespace to the left of the ending " are ignored

var name = "fritz";
string embeddedXML = $"""
       <element attr = "content">
           <body style="normal">
               Here is the {name}
           </body>
           <footer>
               Excerpts from "An amazing story"
           </footer>
       </element >
       """;

//Console.WriteLine(embeddedXML);

double Latitude = 0.0d, Longitude = 0.0d;

// multiple $$ indicate how many {{ }} are needed to trigger the interpolation
var location = $$"""
   You are at {{{Latitude}}, {{Longitude}}}
   """;
// Console.WriteLine(location);

#endregion