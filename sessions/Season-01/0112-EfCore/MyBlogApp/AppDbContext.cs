using Microsoft.EntityFrameworkCore;

namespace MyBlogApp;

public class AppDbContext : DbContext
{

    public DbSet<BlogPost> Posts { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var conn = @"Data Source=appdb.db;";
        optionsBuilder.UseSqlite(conn);
            // .LogTo(x => Console.WriteLine($"Db: '{x}'"));

        base.OnConfiguring(optionsBuilder);
    }

}