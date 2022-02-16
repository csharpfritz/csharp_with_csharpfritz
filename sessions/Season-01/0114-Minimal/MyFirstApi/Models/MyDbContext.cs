using Microsoft.EntityFrameworkCore;

namespace MyFirstApi.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

    }
}