namespace MyFirstApi.Models
{
    public record class Contact
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string StreamingService { get; set; }

    }
}