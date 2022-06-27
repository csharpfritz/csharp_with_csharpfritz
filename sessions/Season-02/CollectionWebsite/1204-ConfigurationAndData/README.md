# Session 1204: Configuration and Data

We're building on the previous state of our application that showed content loaded from a JSON file on disk to use application configuration, Entity Framework Core and a SQLite database to present information about our collection.   

## Agenda

1. Refactoring the project to remove references to 'Hats'
2. Introducing IConfiguration
3. Loading configuration
  - appsettings.json
  - Environment Variables
4. Introducing Entity Framework Core
5. Create a DataContext
6. Prepopulate data with Data Seeding

### Notes to add:

- More information about [Configuration](https://docs.microsoft.com/aspnet/core/fundamentals/configuration) from the Microsoft documentation website
- You can also [load connection strings from Configuration](https://docs.microsoft.com/dotnet/api/microsoft.extensions.configuration.configurationextensions.getconnectionstring) in a `ConnectionStrings` section with code like the following: 

```csharp
builder.Services.AddDbContext<MyCollectionSite.Models.CollectionContext>(
  options => options.UseSqlite(
    builder.Configuration.GetConnectionString("MyConnectionString")
  )
);
```