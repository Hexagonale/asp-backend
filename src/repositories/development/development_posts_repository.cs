using Microsoft.EntityFrameworkCore;
using Api.Database;

namespace Api.Repositories;

public class DevelopmentPostsRepository : PostsRepository
{
    private static AppDbContext context = new AppDbContext();

    public Post getPost(int id)
    {
        Post user = context.posts.Find(id);
        
        return user;
    }

    public List<Post> getPosts()
    {
        DbSet<Post> posts = context.posts;

        return posts.ToList();
    }

    public bool addPost(string title, string content, User createdBy)
    {
        Post post = new Post(title, content, createdBy);

        context.posts.Add(post);
        context.SaveChanges();

        return true;
    }
}
