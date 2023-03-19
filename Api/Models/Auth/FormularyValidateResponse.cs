namespace Api.Models.Auth;

public class FormularyValidateResponse
{
    public bool Valid { get; set; }
    public bool error { get; set; }
    public string Message { get; set; }
}