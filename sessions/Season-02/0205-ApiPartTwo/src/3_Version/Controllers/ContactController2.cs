using System.Collections.Generic;
using System.Linq;
using _3_Version.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3_Version.Controllers {

  [ApiController]
  [ApiVersion("2.0")]
  [Produces("application/json")]
  [Route("{version:apiVersion}/Contact")] // v{version:apiVersion}/
  public class ContactV2Controller : Controller {

    private static readonly  List<Contact> _Contacts = new List<Contact> {
      new Contact {
        Id=1,
        FirstName="Jeff",
        LastName="Fritz"
      },
      new Contact {
        Id=2,
        FirstName="Mary",
        LastName="Contrary"
      }
    };

    /// <summary>
    /// Get the contact identified by id
    /// </summary>
    /// <param name="id">The unique identifier for the contact sought</param>
    /// <returns></returns>
    /// <response code="200">Returns the contact sought</response>
    /// <response code="404">Unable to find a contact with the id requested</response>
   [HttpGet("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Contact2> GetById2(int id) {
      
      // if (!_Contacts.Any(c => c.Id == id)) return NotFound();
      
      // return _Contacts.FirstOrDefault(c => c.Id == id);

      return new Contact2() {
        Id=99,
        FirstName="Joe",
        LastName="Bag O'Donuts",
        Email="joe@bagodonuts.com"
      };

    }

  }

}