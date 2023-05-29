using System.Text.Json.Serialization;
using Api.Models.Register;
using Repository.Models.Database.User;

namespace Api.Models;

public class UserModel : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("password")]
    public string? Password { get; set; }
    
    [JsonPropertyName("type")]
    public UserTypeModel UserType { get; set; }
    
    [JsonPropertyName("token")]
    public string? Token { get; set; }
    
    public static UserModel FromFormulary(Formulary formulary)
    {
        return new UserModel
        {
            Name = formulary.Name,
            Email = formulary.Email,
            Password = formulary.Password,
            UserType = new UserTypeModel(null, formulary.Type)
        };
    }

    public static UserModel LoadData(ApplicationUser user)
    {
        UserTypeModel type = new(user.Id , user.Type);
        return new UserModel
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            InsertDate = user.InsertDate,
            UpdateDate = user.UpdateDate,
            UserType = type
        };
    }

    public ApplicationUser ToEntity()
    {
        var type = UserTypeModel.GetLogicalByUserType(UserType.Type);
        return new ApplicationUser
        {
            Email = Email ?? string.Empty,
            Name = Name ?? string.Empty,
            Password = Password ?? string.Empty,
            Type = type,
            UpdateDate = DateTime.UtcNow
        };
    }
}