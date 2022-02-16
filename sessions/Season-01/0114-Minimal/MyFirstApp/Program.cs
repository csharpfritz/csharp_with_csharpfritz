using LINQtoCSV;
// using MyFirstApp.Models;

Console.WriteLine("Hello, World!");

var ctx = new CsvContext();
var contacts = ctx.Read<Contact>("contacts.csv");

foreach (var contact in contacts)
{
    Console.WriteLine(contact);
}