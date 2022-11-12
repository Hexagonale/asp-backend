namespace Api.Controllers.AuthController.Models {
    public record LoginRequest{
        public string username { get; set; }

        public string password { get; set; }
    }
}