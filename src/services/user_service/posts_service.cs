using Api.Repositories;
using Api.Database;

namespace Api.Services;

public class PostsService
{
    public PostsService(PostsRepository postsRepository, UsersRepository usersRepository)
    {
        _postsRepository = postsRepository;
        _usersRepository = usersRepository;
    }

    private readonly PostsRepository _postsRepository;

    private readonly UsersRepository _usersRepository;

    public List<Post> getPosts() {
        return _postsRepository.getPosts();
    }

    public Post addPost(string title, string content, int userId) {
        User user = _usersRepository.getUser(userId);
        if(user is null) {
            return null;
        }

        return _postsRepository.addPost(title, content, DateTime.Now, user);
    }
}
