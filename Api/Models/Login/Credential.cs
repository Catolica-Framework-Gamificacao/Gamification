using System.Text.Json.Serialization;

namespace Api.Models.Login;

public class Credential
{
    [JsonPropertyName("email")]
    public string email { get; set; }

    [JsonPropertyName("password")]
    public string password { get; set; }
}