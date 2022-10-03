using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyCollectionSite.Models;

public class CollectionContext : IdentityDbContext<IdentityUser>
{

    public CollectionContext(DbContextOptions<CollectionContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<CollectionItem>().HasData(
            new CollectionItem
            {
                Id=1,
                Name = "Atari",
                Description = "Black hat with the classic Atari logo and Japanese text for Atari under the brim",
                ImageURL = "https://hatcollection.blob.core.windows.net/hat-images/atari.jpg",
                Acquired = new DateTime(2018, 01, 01)
            },
            new CollectionItem
            {
                Id=2,
                Name = "Blazor",
                Description = "White hat with purple Blazor logo",
                ImageURL = "https://hatcollection.blob.core.windows.net/hat-images/blazor.jpg",
                Acquired = new DateTime(2019, 04, 20)
            }
        );

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<CollectionItem> CollectionItems => Set<CollectionItem>();

} 