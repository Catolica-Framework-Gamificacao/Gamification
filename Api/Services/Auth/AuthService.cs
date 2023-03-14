using Api.Models.Auth;
using Api.Models.Login;
using Api.Models.Register;
using Repository.Models.Database.User;

namespace Api.Services.Auth;

public class AuthService : IAuthService
{
    public AuthenticationResponse Authenticate(Credential credential)
    {
        var user = new ApplicationUser();
        var success = false;
        string error = null;
        
        
        return new AuthenticationResponse
        {
            User = user,
            Success = success,
            Error = error
        };
    }

    public RegisterResponse Register(Formulary formulary)
    {
        return new RegisterResponse
        {
            User = null,
            Success = false,
            Error = null
        };
    }
}