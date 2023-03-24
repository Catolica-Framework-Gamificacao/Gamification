using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Models;
using Api.Models.Auth;
using Api.Models.Login;
using Api.Models.Register;
using Api.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IApplicationUserRepository _repository;

    public AuthService(IApplicationUserRepository repository)
    {
        _repository = repository;
    }

    public AuthenticationResponse Authenticate(Credential credential)
    {
        var user = _repository.GetByKey(credential.Email, credential.Password);
        var userModel = new UserModel();
        var success = false;
        string? error = null;
        
        if (user != null)
        {
            userModel = UserModel.LoadData(user);
            userModel.Token = GenerateJwtToken(user.Email);
            success = true;
        }
        else
        {
            error = "Bad credentials";
        }
        
        
        return new AuthenticationResponse
        {
            User = userModel,
            Success = success,
            Error = error
        };
    }

    public RegisterResponse Register(Formulary formulary)
    {
        var validateResponse  = ValidateFormulary(formulary);

        if (validateResponse.HasCritics())
        {
            return new RegisterResponse
            {
                User = null,
                Success = validateResponse.Valid,
                Message = validateResponse.Message
            };
        }
    
        var model = UserModel.FromFormulary(formulary);
        _repository.Save(model);

        return new RegisterResponse
        {
            User = model,
            Success = true,
            Message = null
        };
    }

    private FormularyValidateResponse ValidateFormulary(Formulary formulary)
    {
        var response = new FormularyValidateResponse();
        
        var hasSomeMandatoryFieldEmpty = formulary.HasSomeMandatoryFieldEmpty();
        if (hasSomeMandatoryFieldEmpty)
        {
            response.Error = true;
            response.Message = "Some mandatory fields are empty.";
            return response;
        }

        var emailIsValid = formulary.EmailIsValid();
        if (!emailIsValid)
        {
            response.Error = true;
            response.Message = $"'{formulary.Email}' is not a valid e-mail address";
        }

        if (response.HasCritics()) return response;
        
        var user = _repository.GetByKey(formulary.Email, formulary.Password);
        if (user != null)
        {
            response.Error = true;
            response.Message = "User already exists."; 
        }
        else
        {
            response.Valid = true;
        }

        return response;
    }
    
    private static string GenerateJwtToken(string email)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AppConfiguration.JwtKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim(ClaimTypes.Name, email)
            }),
            Expires = DateTime.UtcNow.AddMinutes(60),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
}