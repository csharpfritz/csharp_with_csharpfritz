using System.ComponentModel.DataAnnotations;

namespace MyBlogApp;

public class BlogPost {

    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime PublishedUtc { get; set; }

    public string Content { get; set; }

    public Author Author { get; set; }

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public override string ToString() {
      return $"{Title} ({Id})";
    }

  }
