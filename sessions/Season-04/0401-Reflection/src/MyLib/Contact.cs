using System;
using BaseLib;

namespace MyLib
{
    public class Contact : IContact
    {

	public string GivenName { get; set; }

	public string SurName { get; set; }

	public int Age { get; set; }

    }
}
