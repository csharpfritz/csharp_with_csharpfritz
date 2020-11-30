using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleEntityFramework
{
	public class BlogPost {

		public int Id { get; set; }

		public string Title { get; set; }

		public DateTime PublishedUtc { get; set; }

		public string Content { get; set; }

		public Author Author { get; set; }

		public int? AuthorId { get; set; }

		public IList<Tag> Tags { get; set; } = new List<Tag>();

		public override string ToString() {

			var tagsText = "";
			if (Tags.Any()) tagsText = $" Tagged with: [{string.Join(',', Tags.Select(t => t.Name))}]";

			if (Author == null) return $"{Title} ({Id})" + tagsText;

			return $"{Title} ({Id}) - Written By: {Author.Name}" + tagsText;

		}

	}

}