using Microsoft.EntityFrameworkCore;
using Api.Database;

namespace Api.Repositories;

public class ProductionCommentsRepository : CommentsRepository {
    public ProductionCommentsRepository(AppDbContext context) {
        this.context = context;
    }

    private AppDbContext context;

    public Comment getComment(int id)
    {
        Comment comment = context.comments.Find(id);
        
        return comment;
    }

    public List<Comment> getComments(int postId)
    {
        List<Comment> comments = context.comments.Where(c => c.postId == postId).Include(c => c.author).ToList();

        return comments;
    }

    public Comment addComment(string content, DateTime created, User author, int postId)
    {
        context.users.Attach(author);

        Comment comment = new Comment(content, created, author, postId);
        Comment added = context.comments.Add(comment).Entity;
        context.SaveChanges();

        return added;
    }
}
