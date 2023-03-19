using System.Text.Json.Serialization;
using Api.Models.Register;
using Repository.Models.Enums;

namespace Api.Models;

public class UserModel : BaseModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("password")]
    public string Password { get; set; }
    
    [JsonPropertyName("type")]
    public UserType Type { get; set; }
    
    public static UserModel fromFormulary(Formulary formulary)
    {
        var model = new UserModel();
        model.Name = formulary.Name;
        model.Email = formulary.Email;
        model.Password = formulary.Password;
        model.Type = formulary.Type;
        return model;
    }
}