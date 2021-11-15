namespace _01_Minimal.Models;

public class Contact
{

	public string? Name { get; set; }

	public string? City { get; set; }

	public void Validate()
	{
		Utilities.ValidateArgument("City", !string.IsNullOrEmpty(City));
	}

}
