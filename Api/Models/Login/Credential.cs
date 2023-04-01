using System.Text.Json.Serialization;

namespace Api.Models.Login;

public class Credential
{
    [JsonPropertyName("login")]
    public string Login { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }
}