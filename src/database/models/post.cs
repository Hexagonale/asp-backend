using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database;

[Table("forum_posts")]
public class Post
{
    public Post(int id, string title, string content, DateTime created, User author) {
        this.id = id;
        this.title = title;
        this.content = content;
        this.created = created;
        this.author = author;
    }

    public Post(int id, string title, string content, DateTime created) {
        this.id = id;
        this.title = title;
        this.content = content;
        this.created = created;
    }

    public Post(string title, string content, DateTime created, User author) {
        this.title = title;
        this.content = content;
        this.created = created;
        this.author = author;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id {get; set;}

    public string title {get; set;}

    public string content {get; set;}

    public DateTime created {get; set;}

    public User author {get; set;}
}
