namespace Api.Controllers.AuthController;

public record LoginRequest {
    public string username { get; set; }

    public string password { get; set; }
}