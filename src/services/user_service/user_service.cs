using Api.Repositories;
using Api.Database;

namespace Api.Services;

public class UserService
{
    public UserService(UsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    private readonly UsersRepository _usersRepository;

    public bool authenticate(string username, string password)
    {
        List<User> users = _usersRepository.getUsers();

        foreach (User user in users)
        {
            Console.WriteLine(user.username);
            Console.WriteLine(user.password);
            if (user.username != username)
            {
                continue;
            }

            if (user.password != password)
            {
                continue;
            }

            return true;
        }

        return false;
    }
}
