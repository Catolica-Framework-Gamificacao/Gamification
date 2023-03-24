using Repository.Models.Database.User;

namespace Api.Models.Auth;

public class AuthenticationResponse
{
    public bool Success { get; set; }
    
    public UserModel? User { get; set; }

    public string? Error { get; set; }
    
    public string? Token { get; set; }

    public AuthenticationResponse()
    {
        this.Success = false;
        this.User = null;
        this.Error = null;
        this.Token = null;
    }
}