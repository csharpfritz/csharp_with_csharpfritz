using System;
using Microsoft.EntityFrameworkCore;

namespace SampleEntityFramework
{

	public class AppDbContext : DbContext {

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

			var connString = "Data Source=appdb.db";
			optionsBuilder.UseSqlite(connString);
				// .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<BlogPost> Posts { get; set; }

		public DbSet<Tag> Tags { get; set; }

	}
		
}