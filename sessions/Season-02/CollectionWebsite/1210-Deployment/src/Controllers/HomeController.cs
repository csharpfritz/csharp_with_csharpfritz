using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyCollectionSite.Models;
using System.IO;
using Microsoft.AspNetCore.Diagnostics;

namespace MyCollectionSite.Controllers;

[InspectFilter]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ICollectionRepository repository;

    public HomeController(
        ILogger<HomeController> logger,
        ICollectionRepository repository)

    {
        _logger = logger;
        this.repository = repository;
    }

    public IActionResult Index()
    {

        var ex = new ArgumentNullException("Foo");
        _logger.LogError(ex, "Error while processing request for the home page");
        var items = repository.Get();

        return View(items);
    }

    [HttpGet("/api/Items")]
    public ActionResult<IEnumerable<CollectionItem>> GetApi()
    {
        return Ok(repository.Get());
    }

    [HttpGet("/api/Items/{whereNameStartsWith?}/{orderBy?}")]
    public ActionResult<IEnumerable<CollectionItem>> GetApi(
        string? whereNameStartsWith,
        string? orderBy)
    {

        Func<CollectionItem,string> orderByFunc = orderBy switch
        {
            "name" => item => item.Name,
            "description" => item => item.Description,
            "votes" => item => item.Votes.ToString("000"),
            _ => item => item.Name
        };

        // TODO: Inspect why this isn't returning
        if (string.IsNullOrEmpty(whereNameStartsWith)) {
            return Ok(
                repository.Get().ToArray()
                .OrderBy(orderByFunc)
            );
        }

        return Ok(
            repository.Get()
                .Where(i => i.Name.StartsWith(whereNameStartsWith, true, null))
                .OrderBy(orderByFunc)
            );
    }

    [HttpGet("/api/Items/{id:int}")]
    public ActionResult<CollectionItem> FindItemApi(int id)
    {

        _logger.LogInformation("Finding item with id {id}", id);
        var item = repository.FindById(id);
        return item == CollectionItem.NotFound ?
            NotFound() :
            Ok(item);

    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {

        var exceptionHandlerPathFeature =
                HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        
      
        var exception = exceptionHandlerPathFeature.Error;
        ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;


        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
