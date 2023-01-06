using Api.Repositories;
using Api.Database;

namespace Api.Services;

public class CommentsService
{
    public CommentsService(CommentsRepository commentsRepository)
    {
        _commentsRepository = commentsRepository;
    }

    private readonly CommentsRepository _commentsRepository;

}
