using Microsoft.AspNetCore.Mvc;
using Api.Services;

namespace Api.Controllers.AuthController;

[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly ISession _session;

    private readonly ILogger<AuthController> _logger;

    private readonly UsersService _usersService;

    public AuthController(IHttpContextAccessor httpContextAccessor, ILogger<AuthController> logger, UsersService usersService)
    {
        _session = httpContextAccessor.HttpContext.Session;
        _logger = logger;
        _usersService = usersService;
    }

    [HttpPost]
    [Route("register")]
    public IActionResult register([FromBody] RegisterRequest request)
    {
        if (request.username == null || request.password == null)
        {
            return StatusCode(400);
        }

        if (request.username == "" || request.password == "")
        {
            return StatusCode(400);
        }

        bool success = _usersService.createUser(request.username, request.password);
        if(!success) {
            return StatusCode(403);
        }

        return Ok();
    }

    [HttpPost]
    [Route("login")]
    public IActionResult login([FromBody] LoginRequest request)
    {
        if (request.username == null || request.password == null)
        {
            return StatusCode(400);
        }

        if (request.username == "" || request.password == "")
        {
            return StatusCode(400);
        }

        int? userId = _usersService.authenticate(request.username, request.password);
        if (userId is null)
        {
            return StatusCode(401);
        }

        _session.SetInt32("id", userId.Value);
        return Ok();
    }

    [HttpGet]
    [Route("logout")]
    public IActionResult logout()
    {
        _session.Remove("id");

        return new RedirectResult(url: "/");
    }
}
