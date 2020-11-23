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

## Defining a class to be stored in a table

## EF Tools

### Installation

### Migrations

### Database Update

## CRUD Operations

### Reading Data
WithNoTracking()

### Creating Data

### Updating Data

### Deleting Data

## Relational Data

Foreign Keys / Navigation property

## Working with Files 

### Streams

### File.Open

### FileWatcher
