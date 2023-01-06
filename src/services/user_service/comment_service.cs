using Api.Repositories;
using Api.Database;

namespace Api.Services;

public class CommentService
{
    public CommentService(CommentsRepository commentsRepository)
    {
        _commentsRepository = commentsRepository;
    }

    private readonly CommentsRepository _commentsRepository;

}
