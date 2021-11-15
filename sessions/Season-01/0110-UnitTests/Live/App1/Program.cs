// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Fritz and Friends!");

var calc = new MyLibrary.Calculator();
Console.WriteLine($"The sum of 2 and 2 is: " +
    $"{calc.Sum(2,2)}");