using Api.Repositories;
using Api.Database;

namespace Api.Services;

public class LikesService
{
    public LikesService(LikesRepository likesRepository)
    {
        _likesRepository = likesRepository;
    }

    private readonly LikesRepository _likesRepository;
}
