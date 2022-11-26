using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database;

[Table("forum_users")]
public class User
{
    public User(int id, string username, string password) {
        this.id = id;
        this.username = username;
        this.password = password;
    }

    public User(string username, string password) {
        this.username = username;
        this.password = password;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id {get; set;}

    [Required]
    [Column("username")]
    [StringLength(30)]
    public string username {get; set;}

    [Column("password")]
    [Required]
    [StringLength(20)]
    public string password {get; set;}
}
