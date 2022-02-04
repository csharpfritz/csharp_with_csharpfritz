// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using MyBlogApp;

var ctx = new AppDbContext();

// ctx.Tags.AddRange(
//     new Tag { Name = "C#"},
//     new Tag { Name = "Entity Framework" },
//     new Tag { Name = "ASP.NET Core"},
//     new Tag { Name = "Blazor"}
// );
// ctx.SaveChanges(); 

var tags = ctx.Tags.First(t => t.Name == "C#");
ctx.Posts.Find(1).Tags.Add(tags);
ctx.SaveChanges();



// var newAuthor = new Author {
//     Name = "csharpfritz",
//     EmailAddress = "jeff@jeffreyfritz.com"
// };
// ctx.Authors.Add(newAuthor);

// var newAuthor = ctx.Authors.First();
// ctx.Posts.Find(1).Author = newAuthor;
// ctx.SaveChanges();

// var recentBlogPosts = await ctx.Posts
//     .OrderByDescending(b => b.PublishedUtc)
//     .Take(5)
//     .ToArrayAsync();

var recentBlogPosts = ctx.Authors.Include(a => a.BlogPosts).First();

foreach (var item in recentBlogPosts.BlogPosts)
{
    System.Console.WriteLine($"{item.Title} - {item.Author}");
}

/* */

/*

var newPost = new BlogPost {
    Title = "My second post",
    Content = "This is my second blog post.\n\n NARF!",
    PublishedUtc = DateTime.UtcNow
};

ctx.Posts.Add(newPost);


var thirdPost = new BlogPost {
    Title = "Yet Another Post",
    Content = "I like to blog!",
    PublishedUtc = DateTime.UtcNow
};

ctx.Posts.Add(thirdPost);
ctx.SaveChanges();
*/

