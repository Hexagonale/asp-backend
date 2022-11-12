using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Controllers.AuthController.Models;
using Api.Services;

namespace Api.Controllers.AuthController
{
    [ApiController]
    [Route("auth")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        private readonly UserService _usersService;

        public LoginController(ILogger<LoginController> logger, UserService usersService)
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
        public IActionResult login(LoginRequest request)
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
}
