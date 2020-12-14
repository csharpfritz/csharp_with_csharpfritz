using System;
using System.ComponentModel.DataAnnotations;

namespace MyCoolApp.Web.Models
{

  [Serializable]
  public class Person
  {

    [Display(Name = "Name")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "City")]
    public string City { get; set; }

    [Display(Name = "Age")]
    [Range(3, 80)]
    public int Age { get; set; }

  }

}