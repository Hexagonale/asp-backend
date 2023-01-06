namespace Api.Controllers;

public record AddPostRequest {
    public string title {get; set;}

    public string content {get; set;}
}