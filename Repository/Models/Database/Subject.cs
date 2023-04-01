namespace Repository.Models.Database;

public class Subject : BaseEntity
{
    public string Uuid { get; set; }
    public string Name { get; set; }
    public Teacher Teacher { get; set; }
}