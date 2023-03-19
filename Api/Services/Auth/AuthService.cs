using Api.Models;
using Api.Models.Auth;
using Api.Models.Login;
using Api.Models.Register;
using Api.Repositories.Interfaces;
using Repository.Models.Database.User;

namespace Api.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IApplicationUserRepository Repository;

    public AuthService(IApplicationUserRepository repository)
    {
        Repository = repository;
    }

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
        var validateResponse  = ValidateFormulary(formulary);
        
        var model = UserModel.fromFormulary(formulary);
        Repository.Save(model);
        return new RegisterResponse
        {
            User = null,
            Success = false,
            Error = null
        };
    }

    public static FormularyValidateResponse ValidateFormulary(Formulary formulary)
    {
        var response = new FormularyValidateResponse();
        bool hasSomeMandatoryFieldEmpty = formulary.HasSomeMandatoryFieldEmpty();
        if (hasSomeMandatoryFieldEmpty)
        {
            response.error = true;
            response.Message = "Some mandatory fields are empty.";
            response.Valid = false;
        }
        
        // check if exists on database
        
        return response;
    }
}