using Microsoft.AspNetCore.Mvc;

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

    public IActionResult newPost()
    {
        return View("newPost");
    }

    [Route("home/posts/{id}")]
    public IActionResult postDetails(int id)
    {
        ViewBag.postId = id;

        return View("postDetails");
    }
}
