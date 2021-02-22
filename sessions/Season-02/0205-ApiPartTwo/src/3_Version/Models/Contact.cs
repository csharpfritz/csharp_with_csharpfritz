using System.ComponentModel.DataAnnotations;

namespace _3_Version.Models
{
    
  public class Contact {

    /// <summary>
    /// A unique identifier for the contact
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// The contact's given name
    /// </summary>
    /// <value></value>
    [MaxLength(50)]
    public string FirstName { get; set; }

    /// <summary>
    /// The contact's family name or surname
    /// </summary>
    /// <value></value>
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

  }

}