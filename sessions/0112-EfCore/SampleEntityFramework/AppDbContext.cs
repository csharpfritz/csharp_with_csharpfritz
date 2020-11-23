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

    public DbSet<BlogPost> Posts { get; set; }

  }

}