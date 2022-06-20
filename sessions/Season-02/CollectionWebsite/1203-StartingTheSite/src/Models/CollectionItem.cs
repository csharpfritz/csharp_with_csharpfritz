using System.ComponentModel.DataAnnotations;

namespace MyCollectionSite.Models;

public class CollectionItem
{

 [Required]
 public string Name { get; set; }

 public string? Description { get; set; }

 public string? ImageURL { get; set; }   

 public DateTime Acquired { get; set; }

}