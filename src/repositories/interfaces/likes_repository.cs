using Api.Database;

namespace Api.Repositories;

public interface LikesRepository
{
    Like getLike(int id);

    List<Like> getLikes();

    public bool addLike(DateTime created, User author, Post post);
}
