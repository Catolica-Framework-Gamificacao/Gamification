﻿using System.Net.Mail;
using System.Text.Json.Serialization;
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
        var valid = true;
            
        try
        { 
            new MailAddress(this.Email);
        }
        catch
        {
            valid = false;
        }

        return valid;
    }

}