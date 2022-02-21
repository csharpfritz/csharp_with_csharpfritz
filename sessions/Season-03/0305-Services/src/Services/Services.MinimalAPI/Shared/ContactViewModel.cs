using System.ComponentModel.DataAnnotations;

namespace Services.MinimalAPI.Shared;
#nullable disable

public class ContactViewModel
{

	[Key]
	public int Id { get; set; }

	[Required]
	public string Name { get; set; }

	[EmailAddress, Required]
	public string EmailAddress { get; set; }

}

#nullable enable