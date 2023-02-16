using Api.Repositories;
using Api.Database;

namespace Api.Services;

public class CommentsService
{
    public CommentsService(CommentsRepository commentsRepository, UsersRepository usersRepository, PostsRepository postsRepository)
    {
        _commentsRepository = commentsRepository;
        _usersRepository = usersRepository;
        _postsRepository = postsRepository;
    }

    private readonly CommentsRepository _commentsRepository;
    private readonly UsersRepository _usersRepository;
    private readonly PostsRepository _postsRepository;

    public List<Comment> getComments(int postId) {
        return _commentsRepository.getComments(postId);
    }

    public Comment addComment(string content, DateTime created, int authorId, int postId) {
        User author = _usersRepository.getUser(authorId);
        if(author == null) {
            return null;
        }

        Post post = _postsRepository.getPost(postId);
        if(post == null) {
            return null;
        }

        return _commentsRepository.addComment(content, created, author, postId);
    }
}
