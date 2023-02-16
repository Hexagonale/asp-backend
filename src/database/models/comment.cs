using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database;

[Table("forum_comments")]
public class Comment
{
    public Comment(int id, string content, DateTime created, User author, int postId) {
        this.id = id;
        this.content = content;
        this.created = created;
        this.author = author;
        this.postId = postId;
    }

    public Comment(int id, string content, DateTime created) {
        this.id = id;
        this.content = content;
        this.created = created;
    }

    public Comment(string content, DateTime created, User author, int postId) {
        this.content = content;
        this.created = created;
        this.author = author;
        this.postId = postId;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id {get; set;}

    public string content {get; set;}

    public DateTime created {get; set;}

    public User author {get; set;}

    public int postId {get; set;}
}
