using Microsoft.EntityFrameworkCore;
using Api.Database;

namespace Api.Repositories;

public class DevelopmentUsersRepository : UsersRepository
{
    private static AppDbContext context = new AppDbContext();

    public User getUser(int id)
    {
        User user = context.users.Find(id);
        
        return user;
    }

    public List<User> getUsers()
    {
        DbSet<User> users = context.users;

        return users.ToList();
    }

    public bool addUser(string username, string password)
    {
        User user = new User(username, password);

        context.users.Add(user);
        context.SaveChanges();

        return true;
    }
}
