namespace Api.Models.Auth;

public class FormularyValidateResponse
{
    public bool Valid { get; set; }
    public bool Error { get; set; }
    public string? Message { get; set; }

    public FormularyValidateResponse()
    {
        this.Valid = false;
        this.Error = false;
        this.Message = null;
    }

    public bool HasCritics()
    {
        return !string.IsNullOrEmpty(this.Message) && (this.Error || !this.Valid);
    }
}