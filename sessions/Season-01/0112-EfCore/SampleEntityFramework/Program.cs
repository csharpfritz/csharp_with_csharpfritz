using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SampleEntityFramework
{
	class Program
	{
		static void Main(string[] args)
		{

			var db = new AppDbContext();
			// AddPost(db);
			//  GetPosts(db);      
			// UpdatePost(db);
			// DeletePost(db);

			//AddPostWithAuthor(db);
			// CreateTagsAndAddToFirstPost(db);
			GetPosts(db);      
			

		}

		private static void GetPosts(AppDbContext db)
		{

				// var posts = db.Posts.AsNoTracking().Where(p => p.Id < 10);
				var posts = db.Posts
					.Include(p => p.Author)
					.Include(p => p.Tags)
					.AsNoTracking().Where(p => p.Id < 10);
				// Console.WriteLine(posts.ToQueryString());
				if (!posts.Any()) {
						Console.WriteLine("** No blog posts found **");
						return;
				}

				foreach (var p in posts)
				{
						Console.WriteLine(p.ToString());
				}

		}

		private static void AddPost(AppDbContext db)
		{
			var newPost = new BlogPost
			{
				Title = "My first post",
				PublishedUtc = DateTime.UtcNow,
				Content = "This is my first post and I am very proud of it"
			};

			db.Posts.Add(newPost);
			db.SaveChanges();
		}

		private static void UpdatePost(AppDbContext db)
		{
			
				var post = db.Posts.First(p => p.Id == 1);
				post.Title = "'-- DROP TABLE Posts;";
				db.SaveChanges();

				GetPosts(db);    

		}

		private static void DeletePost(AppDbContext db)
		{
			
			db.Posts.Remove(db.Posts.First(p => p.Id == 1));
			db.SaveChanges();

			GetPosts(db);

		}



    private static void AddPostWithAuthor(AppDbContext db)
    {

			var a = new Author() {
				Name = "Jeff Fritz",
				TwitterUserName = "csharpfritz"
			};
			var newPost = new BlogPost {
				Author = a,
				Title = "Live Coding with Twitch",
				Content = "Today is my 3 year anniversary live coding on Twitch..."
			};

			db.Posts.Add(newPost);
			db.SaveChanges();

    }

		private static void CreateTagsAndAddToFirstPost(AppDbContext db)
		{
			
			var personalTag = new Tag { Name="Personal"};
			var techTag = new Tag { Name="Technical"};

			db.Tags.AddRange(personalTag, techTag);
			
			var firstPost = db.Posts.OrderBy(p => p.Id).First();
			firstPost.Tags.Add(personalTag);

			var secondPost = db.Posts.OrderBy(p => p.Id).Skip(1).First();
			secondPost.Tags.Add(personalTag);
			secondPost.Tags.Add(techTag);

			db.SaveChanges();

		}



	}
}
