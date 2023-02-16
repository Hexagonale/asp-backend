using Api.Database;

namespace Api.Repositories;

public interface CommentsRepository
{
    Comment getComment(int id);

    List<Comment> getComments();

    public Comment addComment(string content, DateTime created, User author, int postId);
}
