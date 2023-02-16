using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database;

[Table("forum_users")]
public class User
{
    public User(int id, string username, string password, bool isAdmin) {
        this.id = id;
        this.username = username;
        this.password = password;
        this.isAdmin = isAdmin;
    }

    public User(string username, string password, bool isAdmin) {
        this.username = username;
        this.password = password;
        this.isAdmin = isAdmin;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id {get; set;}

    public string username {get; set;}

    public string password {get; set;}

    public bool isAdmin {get; set;}
}
