using System.Collections.Generic;

namespace SampleEntityFramework
{
	public class Tag {

		public int Id { get; set; }

		public string Name { get; set; }

		public IList<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();

	}

}