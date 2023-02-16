namespace Api.Controllers;

public record AddCommentRequest {
    public string content {get; set;}

    public int postId {get; set;}
}