namespace Repository.Models.Database.User;

public class ApplicationUser : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Type { get; set; }

}