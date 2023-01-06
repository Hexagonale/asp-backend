using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult index()
    {
        return View("index");
    }

    public IActionResult login()
    {
        return View("login");
    }
    public IActionResult register()
    {
        return View("register");
    }
}
