using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database;

[Table("forum_posts")]
public class Post
{
    public Post(int id, string title, string content, User createdBy) {
        this.id = id;
        this.title = title;
        this.content = content;
        this.createdBy = createdBy;
    }

    public Post(string title, string content, User createdBy) {
        this.title = title;
        this.content = content;
        this.createdBy = createdBy;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id {get; set;}

    [Required]
    [Column("title")]
    public string title {get; set;}

    [Column("content")]
    [Required]
    public string content {get; set;}

    public User createdBy {get; set;}
}
