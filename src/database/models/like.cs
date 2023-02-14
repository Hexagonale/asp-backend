using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database;

[Table("forum_likes")]
public class Like
{
    public Like(int id, DateTime created, User author, Post post) {
        this.id = id;
        this.created = created;
        this.author = author;
        this.post = post;
    }
    
    public Like(int id, DateTime created) {
        this.id = id;
        this.created = created;
    }

    public Like(DateTime created, User author, Post post) {
        this.created = created;
        this.author = author;
        this.post = post;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id {get; set;}

    public DateTime created {get; set;}

    public User author {get; set;}

    public Post post {get; set;}
}
