using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Models;
using Api.Models.Auth;
using Api.Models.Enums;
using Api.Models.Login;
using Api.Models.Register;
using Api.Services.Student;
using Api.Services.Teacher;
using Api.Services.User;
using Microsoft.IdentityModel.Tokens;
using Repository.Database;

namespace Api.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IApplicationUserService _applicationUserService;
    private readonly ITeacherService _teacherService;
    private readonly IStudentService _studentService;

    public AuthService(IApplicationUserService applicationUserService, ITeacherService teacherService, IStudentService studentService)
    {
        _applicationUserService = applicationUserService;
        _teacherService = teacherService;
        _studentService = studentService;
    }

    public AuthenticationResponse Authenticate(Credential credential)
    {
        var user = _applicationUserService.GetByKey(credential.Login, credential.Password);
        var userModel = new UserModel();
        var success = false;
        string? error = null;
        string? token = null;
        
        if (user != null)
        {
            userModel = UserModel.LoadData(user);
            token = GenerateJwtToken(user.Email);
            userModel.Token = token;
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
            Error = error,
            Token = token
        };
    }

    public RegisterResponse Register(Formulary formulary)
    {
        var validateResponse = ValidateFormulary(formulary);
        var message = "";

        if (validateResponse.HasCritics())
        {
            return new RegisterResponse
            {
                User = null,
                Success = validateResponse.Valid,
                Message = validateResponse.Message
            };
        }

        var type = formulary.Type;
        var model = UserModel.FromFormulary(formulary);
        
        using (var context = new GamificationContext())
        {
            var user = _applicationUserService.Save(model, context);
            if (type.Equals(UserType.Student))
            {
                Repository.Models.Database.Student student = new(formulary.Ra, user);
                _studentService.Save(student, context);
                message = "The student has been successfully registered";
            } else if (type.Equals(UserType.Teacher))
            {
                Repository.Models.Database.Teacher teacher = new(user);
                _teacherService.Save(teacher, context);
                message = "The teacher has been successfully registered";
            }

            model.UserType.UserId = user.Id;
            context.SaveChanges();
        }
        
        return new RegisterResponse
        {
            User = model,
            Success = true,
            Message = message
        };
    }

    private FormularyValidateResponse ValidateFormulary(Formulary formulary)
    {
        var response = new FormularyValidateResponse();

        #region BASCIC FORMULARY VALIDATION

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
        
        var user = _applicationUserService.GetByKey(formulary.Email, formulary.Password);
        if (user != null)
        {
            response.Error = true;
            response.Message = "User already exists."; 
        }
        else
        {
            response.Valid = true;
        }
        
        if (response.HasCritics()) return response;

        #endregion

        var type = formulary.Type;

        #region STUDENT VALIDATION

        if (type.Equals(UserType.Student))
        {
            if (formulary.Ra.IsNullOrEmpty())
            {
                response.Error = true;
                response.Message = "Field 'RA' is Mandatory";
                response.Valid = false;
            }

            if (response.HasCritics()) return response;
        }

        #endregion
        
        #region TEACHER VALIDATION

        if (type.Equals(UserType.Teacher))
        {
            
        }

        #endregion

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