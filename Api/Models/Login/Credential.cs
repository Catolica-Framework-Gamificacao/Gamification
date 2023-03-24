using System.Text.Json.Serialization;

namespace Api.Models.Login;

public class Credential
{
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }
}