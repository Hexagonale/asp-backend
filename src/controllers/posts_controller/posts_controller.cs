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
    private readonly UsersService _usersService;

    public PostsController(IHttpContextAccessor httpContextAccessor, ILogger<PostsController> logger, PostsService postsService, UsersService usersService)
    {
        _session = httpContextAccessor.HttpContext.Session;
        _logger = logger;
        _usersService = usersService;
        _postsService = postsService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult getPosts()
    {
        List<Post> posts = _postsService.getPosts();

        return Ok(posts);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult getPost(int? id)
    {
        if(id is null) {
            return StatusCode(400);
        }

        Post post = _postsService.getPost(id.Value);
        if(post is null) {
            return StatusCode(404);
        }

        return Ok(post);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult deletePost(int? id)
    {
        if(id is null) {
            return StatusCode(400);
        }

        int? userId = _session.GetInt32("id");
        if(userId is null) {
            return StatusCode(403);
        }

        User user = _usersService.getUser(userId.Value);
        if(user is null) {
            return StatusCode(403);
        }

        Post post = _postsService.getPost(id.Value);
        if(post is null) {
            return StatusCode(404);
        }

        if(post.author.id != user.id && !user.isAdmin) {
            // Only admin can delete someone else's post.
            return StatusCode(403);
        }

        _postsService.removePost(id.Value);

        return Ok();
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
        if (post is null)
        {
            return StatusCode(401);
        }

        return Ok();
    }
}
