using Api.Database;

namespace Api.Repositories;

public interface PostsRepository
{
    Post getPost(int id);

    List<Post> getPosts();

    public Post addPost(string title, string content, DateTime created, User author);

    public bool removePost(int id);
}
