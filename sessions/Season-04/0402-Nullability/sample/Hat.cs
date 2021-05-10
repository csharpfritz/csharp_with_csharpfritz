using System.ComponentModel.DataAnnotations;

namespace sample
{

// #nullable enable

  public class Hat {

    [Required]
    public string Name { get; set; } = string.Empty;

    public int AcquiredYear { get; set; }

    public string Theme { get; set; } = string.Empty;

  }


   public class Foo
    {

        public static void Bar()
        {

            Hat? hat = new();
            //hat.Name = null;

        }

    }
// #nullable restore


    public class Customer
    {


        public string TaxClassification { get; set; } = "Exempt";

    }

}