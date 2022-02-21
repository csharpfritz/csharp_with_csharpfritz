using Microsoft.EntityFrameworkCore;
using Services.MinimalAPI.Shared;

namespace Services.MinimalAPI.Server.Data;

public class MyContext : DbContext
{

	public MyContext(DbContextOptions<MyContext> options) : base(options)
	{

	}

	public DbSet<Contact> Contacts => Set<Contact>();

}
