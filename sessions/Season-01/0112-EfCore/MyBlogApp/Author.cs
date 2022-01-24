namespace MyBlogApp;

public class Author {

    public int Id { get; set; }

    public string Name { get; set; }

    public string EmailAddress { get; set; }

    public List<BlogPost> BlogPosts { get; set; }

    public override string ToString() {
        return $"{Name} <{EmailAddress}>";
    }

  }