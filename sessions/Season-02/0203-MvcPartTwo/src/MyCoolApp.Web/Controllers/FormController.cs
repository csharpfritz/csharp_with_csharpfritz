using Microsoft.AspNetCore.Mvc;
using MyCoolApp.Web.Models;

namespace MyCoolApp.Web.Controllers
{

  public class FormController : Controller
  {

    public IActionResult Basic1()
    {
      return View();
    }

    [HttpPost]
    public IActionResult BasicForm(string search)
    {

      TempData.Add("SearchTerm", search);
      return RedirectToAction("Basic1");

    }

    public IActionResult Model() {
      return View();
    }

    [HttpPost]
    public IActionResult Model(Person p) {

      TempData.Put("Person", p);
      return RedirectToAction("Model");

    }

    public IActionResult Validate() {
      return View();
    }

    [HttpPost]
    public IActionResult Validate(Person p) {

      if (ModelState.IsValid) {
        TempData.Put("Person", p);
        return RedirectToAction("Validate");
      }

      return View(p);

    }

  }

}