namespace Api.Controllers.AuthController.Models;

public record RegisterRequest {
    public string username;
    public string password;
}