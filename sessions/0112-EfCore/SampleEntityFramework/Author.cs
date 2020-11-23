using System.Collections.Generic;

namespace SampleEntityFramework
{
  public class Author {

    public int Id { get; set; }

    public string Name { get; set; }

    public string TwitterUsername { get; set; }

    public IEnumerable<BlogPost> Posts { get; set; }

  }

}