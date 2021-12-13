Console.WriteLine("Hello, World!");

var ctx = new CsvContext();
var contacts = ctx.Read<Contact>("contacts.csv").ToList();

contacts.ForEach(c => Console.WriteLine(c));

public record Contact {
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
}
