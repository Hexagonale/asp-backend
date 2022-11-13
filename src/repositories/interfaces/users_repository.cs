using System.Collections.Generic;
using Api.Repositories.Models;

namespace Api.Repositories.Interfaces;

public interface UsersRepository
{
    User getUser(int id);

    List<User> getUsers();

    bool addUser(string username, string password);
}
