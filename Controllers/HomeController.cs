using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.Models;

namespace BulkyBook.Controllers;

public class HomeController : Controller // goes to Home in view folder.
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }



    public IActionResult Index() // return index in view folder.
    {
        return View();
    }

    public IActionResult Privacy() // return privacy in view folder.
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

