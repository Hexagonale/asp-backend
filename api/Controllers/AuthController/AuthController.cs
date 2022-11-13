using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Controllers.AuthController.Models;
using Api.Services;

namespace Api.Controllers.AuthController;

[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    private readonly UserService _usersService;

    public AuthController(ILogger<AuthController> logger, UserService usersService)
    {
        _logger = logger;
        _usersService = usersService;
    }

    [HttpPost]
    [Route("register")]
    public IActionResult register([FromBody] RegisterRequest request)
    {
        return Ok(request);
    }

    [HttpPost]
    [Route("login")]
    public IActionResult login([FromBody] LoginRequest request)
    {
        if (request.username == null)
        {
            return StatusCode(400);
        }

        if (request.password == null)
        {
            return StatusCode(400);
        }

        bool authenticated = _usersService.authenticate(request.username, request.password);
        if (!authenticated)
        {
            return StatusCode(401);
        }

        return Ok();
    }
}
