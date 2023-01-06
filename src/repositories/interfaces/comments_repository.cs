using Api.Database;

namespace Api.Repositories;

public interface CommentsRepository
{
    Comment getComment(int id);

    List<Comment> getComments();

    public bool addComment(string content, DateTime created, User author, Post post);
}
