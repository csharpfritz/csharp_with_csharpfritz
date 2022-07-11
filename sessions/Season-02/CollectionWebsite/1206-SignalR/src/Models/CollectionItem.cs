using System.ComponentModel.DataAnnotations;

namespace MyCollectionSite.Models;

public class CollectionItem
{

 public static CollectionItem NotFound = new CollectionItem();

 [Key]
 public int Id { get; set; }

 [Required]
 public string Name { get; set; } = null!;

 public string? Description { get; set; }

 public string? ImageURL { get; set; }   

 public DateTime Acquired { get; set; }

}