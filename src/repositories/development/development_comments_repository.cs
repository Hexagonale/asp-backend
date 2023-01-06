using Microsoft.EntityFrameworkCore;
using Api.Database;

namespace Api.Repositories;

public class DevelopmentCommentsRepository : CommentsRepository
{
    private static AppDbContext context = new AppDbContext();

    public Comment getComment(int id)
    {
        Comment comment = context.comments.Find(id);
        
        return comment;
    }

    public List<Comment> getComments()
    {
        DbSet<Comment> comments = context.comments;

        return comments.ToList();
    }

    public bool addComment(string content, DateTime created, User author, Post post)
    {
        Comment comment = new Comment(content, created, author, post);

        context.comments.Add(comment);
        context.SaveChanges();

        return true;
    }
}
