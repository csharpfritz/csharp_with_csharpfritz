namespace MyBlogApp;

public class Tag {

    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<BlogPost> Posts { get; set; }

  }
