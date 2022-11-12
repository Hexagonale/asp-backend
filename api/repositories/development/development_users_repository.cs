using System.Collections.Generic;
using Api.Repositories.Interfaces;
using Api.Repositories.Models;

namespace Api.Repositories
{
    public class DevelopmentUsersRepository : UsersRepository
    {
        public User getUser(int id)
        {
            return new User(1, "", "");
        }

        public List<User> getUsers()
        {
            List<User> users = new List<User>();

            users.Add(new User(1, "admin", "admin"));
            users.Add(new User(2, "user", "user"));

            return users;
        }

        public bool addUser(string username, string password)
        {
            return true;
        }
    }
}
