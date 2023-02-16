using Api.Database;

namespace Api.Repositories;

public interface CommentsRepository
{
    Comment getComment(int id);

    List<Comment> getComments(int postId);

    public Comment addComment(string content, DateTime created, User author, int postId);
}
