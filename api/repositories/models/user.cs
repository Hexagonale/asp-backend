namespace Api.Repositories.Models
{
    public class User
    {
        public User(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }

        public int id;

        public string username;

        public string password;
    }
}
