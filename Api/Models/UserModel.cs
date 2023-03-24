using System.Text.Json.Serialization;
using Api.Models.Register;
using Repository.Models.Database.User;
using Repository.Models.Enums;

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
    public UserType Type { get; set; }
    
    public string? Token { get; set; }
    
    public static UserModel FromFormulary(Formulary formulary)
    {
        return new UserModel
        {
            Name = formulary.Name,
            Email = formulary.Email,
            Password = formulary.Password,
            Type = formulary.Type
        };
    }

    public static UserModel LoadData(ApplicationUser user)
    {
        return new UserModel
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            InsertDate = user.InsertDate,
            UpdateDate = user.UpdateDate,
            Type = user.Type
        };
    }
}