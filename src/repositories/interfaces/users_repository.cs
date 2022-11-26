using Api.Database;

namespace Api.Repositories;

public interface UsersRepository
{
    User getUser(int id);

    List<User> getUsers();

    bool addUser(string username, string password);
}
