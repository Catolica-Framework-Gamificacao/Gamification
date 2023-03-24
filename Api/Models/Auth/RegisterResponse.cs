using Repository.Models.Database.User;

namespace Api.Models.Auth;

public class RegisterResponse
{
    public bool Success { get; set; }
    
    public UserModel? User { get; set; }

    public string? Message { get; set; }
}