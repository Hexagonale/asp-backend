using Microsoft.EntityFrameworkCore;
using Api.Database;

namespace Api.Repositories;

public class DevelopmentLikesRepository : LikesRepository
{
    private static AppDbContext context = new AppDbContext();

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
        Like like = new Like(created, author, post);

        context.likes.Add(like);
        context.SaveChanges();

        return true;
    }
}
