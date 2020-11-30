# Session 12 - Entity Framework Core and Data

We've worked with all sorts of in-memory data storage, manipulation and retrieval up to this point.  Let's start working with a database and write some content to disk.  In .NET, we use Entity Framework Core to interact with relational databases.  While this isn't the only way that you can interact with a database, its the preferred way by many because of the ease of use of Entity Framework Core as an object-relational mapper to convert our object interactions into actions to take against database records.

## The Setup

Let's create a console application as a test-bed for interacting with a database.  Additionally, to ensure that these samples work on every platform and require no additional setup, we will use SQLite (a file-based database) to persist our data.

We can add EntityFramework Core to our project with these commands:

```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

This will fetch the NuGet package containing the libraries and all of the tools for working with our database and add them to our project.


## Introducing DbContext 

DbContext is your gateway to the database.  A descendent of this class contains table references and configuration to connect to your database.  There are two ways to work with this class: 

- Create the class and its classes to work with FIRST, called "Code First"
- Extract a definition and class hierarchy from your existing database, called "Data First"

### Defining a class to be stored in a table

We'll focus on a Code First approach to working with the database.  In this sample, we'll manage a database for our blog.  Let's create a simple Blogpost type:

```c#
  public class BlogPost {

    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime PublishedUtc { get; set; }

    public string Content { get; set; }

    public override string ToString() {
      return $"{Title} ({Id})";
    }

  }
``` 

We can create a `DbContext` for our blog and add a property of type `DbSet<BlogPost>` to define a table to be created for our `BlogPost` objects:

```c#
 public class AppDbContext : DbContext 
  {

    public DbSet<BlogPost> Posts { get; set; }

  }
```

When we want to interact with the `BlogPost` objects in the database, we'll reach into the `Posts` property and use standard LINQ queries as well as collection interactions to add, update, and delete records from the database.

## EF Tools

With these C# classes created, how do we complete the connection to the database?  Enter the ef tools.  These are global tools that run at the command-line and allow you to manage the connection and definition of the database your code will work with.

### Installation

You can intsall the latest version of the ef tools using the following command:

```
dotnet tool install --global dotnet-ef
```

When a new version is available, you can update with this command:

```
dotnet tool update dotnet-ef --global
```

You will now be able to use `ef` tools from the dotnet command line to interact with the database.  First, we'll want to configure a connection to the database.  In this sample, we'll add a method to our `AppDbContext` class, but in real-world applications this would be fetched from application configuration and passed in:

```c#
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

      var conn = @"Data Source=appdb.db;";
      optionsBuilder.UseSqlite(conn);

      base.OnConfiguring(optionsBuilder);
    }
```

### Migrations

We can now start creating **Migrations**, blocks of code that maintain the schema of the database.  Each migration is a unit that can be applied and removed programmatically from the database.  Create your first migration to define the `BlogPost` storage using this command:

```
dotnet ef migrations add "Add BlogPosts"
```

This will create the `Migrations` folder and add some files to it with the definitions of the `Posts` table.  Each time we modify the objects that will be stored in the database, we need to create additional migrations to be applied to the database.

### Database Update

We can apply any newly created migrations to our database with this command:

```
dotnet ef database update
```

You can also go the _OTHER WAY_ and create your DbContext and objects from the database using the command:

```
dotnet ef dbcontext scaffold "Data Source=appdb.db" Microsoft.EntityFrameworkCore.Sqlite
```	

## CRUD Operations

View SQL statement with
query.ToQueryString()
UseSqlite().LogTo()

### Reading Data
WithNoTracking()

### Creating Data

### Updating Data

### Deleting Data

## Relational Data

Foreign Keys / Navigation property
https://docs.microsoft.com/en-us/ef/core/modeling/relationships

Many to Many
![Many to Many relationship](img/ManyToMany.PNG)