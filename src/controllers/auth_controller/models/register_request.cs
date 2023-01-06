namespace Api.Controllers.AuthController;

public record RegisterRequest {
    public string username {get; set; }

    public string password {get; set; }
}