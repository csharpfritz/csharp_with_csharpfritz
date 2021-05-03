using System;

namespace BaseLib
{
    public interface IContact
    {

	string GivenName { get; set; }

	string SurName { get; set; }

	int Age { get; set; }

    }
}
