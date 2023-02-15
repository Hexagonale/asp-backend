using Microsoft.AspNetCore.Mvc;
using Api.Database;
using Api.Services;

namespace Api.Controllers;

[Route("posts")]
public class PostsController : ControllerBase
{
    private readonly ISession _session;

    private readonly ILogger<PostsController> _logger;

    private readonly PostsService _postsService;

    public PostsController(IHttpContextAccessor httpContextAccessor, ILogger<PostsController> logger, PostsService postsService)
    {
        _session = httpContextAccessor.HttpContext.Session;
        _logger = logger;
        _postsService = postsService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult getPosts()
    {
        List<Post> posts = _postsService.getPosts();

        return Ok(posts);
    }

    [HttpPut]
    [Route("")]
    public IActionResult addPost([FromBody] AddPostRequest request)
    {
        int? userId = _session.GetInt32("id");
        if(userId is null) {
            return StatusCode(403);
        }

        if(request.title == null || request.content == null)
        {
            return StatusCode(400);
        }

        if (request.title == "" || request.content == "")
        {
            return StatusCode(400);
        }

        Post post = _postsService.addPost(request.title, request.content, userId.Value);
        if (userId is null)
        {
            return StatusCode(401);
        }

        return Ok();
    }
}
