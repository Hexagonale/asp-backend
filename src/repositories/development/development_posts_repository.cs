using Microsoft.EntityFrameworkCore;
using Api.Database;

namespace Api.Repositories;

public class DevelopmentPostsRepository : PostsRepository {
    public DevelopmentPostsRepository(AppDbContext context) {
        this.context = context;
    }

    private AppDbContext context;

    public Post getPost(int id)
    {
        Post post = context.posts.Where(p => p.id == id).Include(p => p.author).FirstOrDefault();
        
        return post;
    }

    public List<Post> getPosts()
    {
        List<Post> posts = context.posts.Include(p => p.author).ToList();
        
        return posts;
    }

    public Post addPost(string title, string content, DateTime created, User author)
    {
        context.users.Attach(author);

        Post post = new Post(title, content, created, author);

        Post added = context.posts.Add(post).Entity;
        context.SaveChanges();

        return added;
    }

    public bool removePost(int id) {
        Post post = context.posts.Where(p => p.id == id).FirstOrDefault();
        if(post is null) {
            return false;
        }

        context.posts.Remove(post);
        context.SaveChanges();

        return true;
    }
}
