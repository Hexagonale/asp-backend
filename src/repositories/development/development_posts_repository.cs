using Microsoft.EntityFrameworkCore;
using Api.Database;

namespace Api.Repositories;

public class DevelopmentPostsRepository : PostsRepository
{
    private static AppDbContext context = new AppDbContext();

    public Post getPost(int id)
    {
        Post like = context.posts.Find(id);
        
        return like;
    }

    public List<Post> getPosts()
    {
        DbSet<Post> posts = context.posts;

        return posts.ToList();
    }

    public bool addPost(string title, string content, DateTime created, User author)
    {
        Post post = new Post(title, content, created, author);

        context.posts.Add(post);
        context.SaveChanges();

        return true;
    }
}
