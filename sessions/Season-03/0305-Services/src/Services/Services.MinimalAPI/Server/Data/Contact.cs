using Services.MinimalAPI.Shared;

namespace Services.MinimalAPI.Server.Data;
#nullable disable

public class Contact
{

	public int Id { get; set; }

	public string Name { get; set; }

	public string EmailAddress { get; set; }

	public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

	public ContactViewModel AsViewModel()
	{
		return new ContactViewModel
		{
			Id = Id,
			Name = Name,
			EmailAddress = EmailAddress
		};
	}

	public static Contact FromViewModel(ContactViewModel viewModel)
	{
		return new Contact
		{
			Id = viewModel.Id,
			Name = viewModel.Name,
			EmailAddress = viewModel.EmailAddress
		};
	}

}

#nullable enable