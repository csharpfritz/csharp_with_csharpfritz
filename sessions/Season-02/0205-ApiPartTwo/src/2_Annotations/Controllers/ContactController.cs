using System.Collections.Generic;
using System.Linq;
using _2_Annotations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2_Annotations.Controllers {

  [ApiController]
  [Produces("application/json")]
  [Route("[controller]")]
  public class ContactController : Controller {

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
    /// Get all of the contacts in the system
    /// </summary>
    /// <returns>All of the contacts known to the API</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Contact>> Get() {
      return _Contacts;
    }

    /// <summary>
    /// Get the contact identified by id
    /// </summary>
    /// <param name="id">The unique identifier for the contact sought</param>
    /// <returns></returns>
    /// <response code="200">Returns the contact sought</response>
    /// <response code="404">Unable to find a contact with the id requested</response>
   [HttpGet("{id}", Name ="GetById")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Contact> GetById(int id) {
      
      if (!_Contacts.Any(c => c.Id == id)) return NotFound();
      
      return new OkObjectResult(_Contacts.FirstOrDefault(c => c.Id == id));

    }


    /// <summary>
    /// Add a new contact 
    /// </summary>
    /// <param name="newContact">The new contact to create</param>
    /// <remarks>
    /// When creating a new contact, the Id value is not required.
    /// 
    /// Sample request:
    ///
    ///     POST /Contact
    ///     {
    ///        "FirstName": "First Name",
    ///        "LastName": "Last Name"
    ///     }
    ///
    /// </remarks>
    /// <returns></returns>
    /// <response code="201">Created the new contact successfully</response>
    /// <response code="400">Error creating the contact</response>
   [HttpPost()]
   [ProducesResponseType(StatusCodes.Status201Created)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Contact> AddNewContact([FromBody]Contact newContact) {
      
      if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);
      
      newContact.Id = _Contacts.Max(c => c.Id) + 1;
      
      _Contacts.Add(newContact);
      return new CreatedAtRouteResult("GetById", new {id=newContact.Id}, newContact);

    }

  }

}