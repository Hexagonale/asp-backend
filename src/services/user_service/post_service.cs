using Api.Repositories;
using Api.Database;

namespace Api.Services;

public class PostService
{
    public PostService(PostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }

    private readonly PostsRepository _postsRepository;
}
