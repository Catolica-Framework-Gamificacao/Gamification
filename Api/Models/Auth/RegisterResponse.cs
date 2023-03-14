using Repository.Models.Database.User;

namespace Api.Models.Auth;

public class RegisterResponse
{
    public bool Success { get; set; }
    
    public ApplicationUser User { get; set; }

    public string Error { get; set; }
}