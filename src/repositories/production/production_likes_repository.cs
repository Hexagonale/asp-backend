using Microsoft.EntityFrameworkCore;
using Api.Database;

namespace Api.Repositories;

public class ProductionLikesRepository : LikesRepository {
    public ProductionLikesRepository(AppDbContext context) {
        this.context = context;
    }

    private AppDbContext context;

    public Like getLike(int id)
    {
        Like like = context.likes.Find(id);
        
        return like;
    }

    public List<Like> getLikes()
    {
        DbSet<Like> likes = context.likes;

        return likes.ToList();
    }

    public bool addLike(DateTime created, User author, Post post)
    {
        context.users.Attach(author);
        context.posts.Attach(post);

        Like like = new Like(created, author, post);

        context.likes.Add(like);
        context.SaveChanges();

        return true;
    }
}
