using Microsoft.AspNetCore.Mvc;
using Api.Database;
using Api.Services;

namespace Api.Controllers;

[Route("comments")]
public class CommentsController : ControllerBase
{
    private readonly ISession _session;

    private readonly ILogger<CommentsController> _logger;

    private readonly CommentsService _commentsService;

    public CommentsController(IHttpContextAccessor httpContextAccessor, ILogger<CommentsController> logger, CommentsService commentsService)
    {
        _session = httpContextAccessor.HttpContext.Session;
        _logger = logger;
        _commentsService = commentsService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult getComments()
    {
        int? userId = _session.GetInt32("id");
        if(userId is null) {
            return StatusCode(403);
        }

        List<Comment> comments = _commentsService.getComments();

        return Ok(comments);
    }

    [HttpPut]
    [Route("")]
    public IActionResult addComment([FromBody] AddCommentRequest request)
    {
        int? userId = _session.GetInt32("id");
        if(userId is null) {
            return StatusCode(403);
        }

        if(request.content == null || request.content == "")
        {
            return StatusCode(400);
        }

        Comment comment = _commentsService.addComment(request.content, DateTime.Now, userId.Value, request.postId);
        if (comment is null)
        {
            return StatusCode(401);
        }

        return Ok();
    }
}
