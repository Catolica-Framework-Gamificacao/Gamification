using Repository.Models.Enums;

namespace Api.Models.Register;

public class Formulary
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType Type { get; set; }

    public bool HasSomeMandatoryFieldEmpty()
    {
        return this.Name == null || this.Email == null || this.Password == null || this.Type == null;
    }

}