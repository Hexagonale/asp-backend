using Api.Database;

namespace Api.Repositories;

public interface PostsRepository
{
    Post getPost(int id);

    List<Post> getPosts();

    bool addPost(string title, string content, User createdBy);
}
