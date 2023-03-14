using Api.Models.Auth;
using Api.Models.Login;
using Api.Models.Register;

namespace Api.Services.Auth;

public interface IAuthService
{
    public AuthenticationResponse Authenticate(Credential credential);
    public RegisterResponse Register(Formulary formulary);

}