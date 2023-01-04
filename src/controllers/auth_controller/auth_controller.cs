using Microsoft.AspNetCore.Mvc;
using Api.Services;

namespace Api.Controllers.AuthController;

[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly ISession _session;

    private readonly ILogger<AuthController> _logger;

    private readonly UserService _usersService;

    public AuthController(IHttpContextAccessor httpContextAccessor, ILogger<AuthController> logger, UserService usersService)
    {
        _session = httpContextAccessor.HttpContext.Session;
        _logger = logger;
        _usersService = usersService;
    }

    [HttpPost]
    [Route("register")]
    public IActionResult register([FromForm] RegisterRequest request)
    {
        return Ok(request);
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

        _session.SetString("id", userId.Value.ToString());
        return Ok();
    }
}
