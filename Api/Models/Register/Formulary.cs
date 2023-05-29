using System.Net.Mail;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Api.Models.Enums;

namespace Api.Models.Register;

public class Formulary
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("password")]
    public string Password { get; set; }
    
    [JsonPropertyName("type")]
    public UserType Type { get; set; }
    
    [JsonPropertyName("ra")]
    public string? Ra { get; set; }

    public bool HasSomeMandatoryFieldEmpty()
    {
        return string.IsNullOrEmpty(this.Name) || string.IsNullOrEmpty(this.Email) || string.IsNullOrEmpty(this.Password) || this.Type == null;
    }

    public bool EmailIsValid()
    {
        var pattern = @"^(?!\.)[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$";
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);
        return regex.IsMatch(Email);
    }

}