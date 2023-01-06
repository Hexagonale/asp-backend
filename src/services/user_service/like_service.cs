using Api.Repositories;
using Api.Database;

namespace Api.Services;

public class LikeService
{
    public LikeService(LikesRepository likesRepository)
    {
        _likesRepository = likesRepository;
    }

    private readonly LikesRepository _likesRepository;
}
