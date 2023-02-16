using Api.Repositories;
using Api.Database;

namespace Api.Services;

public class UsersService
{
    public UsersService(UsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    private readonly UsersRepository _usersRepository;

    public User getUser(int id) {
        return _usersRepository.getUser(id);
    }

    public User authenticate(string username, string password) {
        List<User> users = _usersRepository.getUsers();

        foreach (User user in users)
        {
            if (user.username != username)
            {
                continue;
            }

            if (user.password != password)
            {
                continue;
            }

            return user;
        }

        return null;
    }

    public bool createUser(string username, string password) {
        List<User> users = _usersRepository.getUsers();
        foreach(User user in users) {
            if(user.username == username) {
                return false;
            }
        }

        return _usersRepository.addUser(username, password, false);
    }
}
