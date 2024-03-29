using Microsoft.EntityFrameworkCore;
using Api.Database;

namespace Api.Repositories;

public class DevelopmentUsersRepository : UsersRepository {
    public DevelopmentUsersRepository(AppDbContext context) {
        this.context = context;
    }

    private AppDbContext context;

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

    public bool addUser(string username, string password, bool isAdmin)
    {
        User user = new User(username, password, isAdmin);

        context.users.Add(user);
        context.SaveChanges();

        return true;
    }
}
