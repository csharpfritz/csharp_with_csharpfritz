using Microsoft.EntityFrameworkCore;

namespace SampleEntityFramework
{

  public class AppDbContext : DbContext 
  {

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

      var conn = @"Data Source=appdb.db;";
      optionsBuilder.UseSqlite(conn);

      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      

      base.OnModelCreating(modelBuilder);
    }

    public DbSet<BlogPost> Posts { get; set; }

    public DbSet<Author> Authors { get; set; }

  }

}