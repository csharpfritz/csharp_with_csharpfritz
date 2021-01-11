using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace _5_ModelBinding.Controllers {

  public class Contact {
    
    public Contact() {}

    public Contact(int id, string first, string last, int age)
    {
        this.id=id;
        this.First=first;
        this.Last = last;
        this.Age = age;
    }

    public int id {get; set;}
    public string First {get; set;}
    public string Last {get; set;}
    [Range(3,30)]
    public int Age {get; set;}

  }

  [ApiController]
  [Route("[controller]")]
  public class ContactController : Controller
  {

    private static readonly List<Contact> _Contacts = new List<Contact>() {
      new Contact(1, "Jeff", "Fritz", 25),
      new Contact(2, "Mary", "Contrary", 28),
      new Contact(3, "Joe", "Bag O'Donuts", 31)
    };

    [HttpGet]
    public IEnumerable<Contact> GetContacts() {
      return _Contacts;
    }

    [HttpGet("{id}")]
    public Contact GetById(int id) {

      return _Contacts.FirstOrDefault(c => c.id == id);

    }

    [HttpPost]
    public ActionResult Add([FromBody]Contact newContact) {

      newContact.id = _Contacts.Max(c => c.id)+1;
      _Contacts.Add(newContact);

      return Ok();

    }

  }

}