using Repository.Models.Database.User;
using Repository.Models.Enums;

namespace Repository.Models.Database;

public class Student : ApplicationUser
{
    public Student() {}
    public Student(string ra, string name, string email, string password, UserType type, List<Subject> subjects, bool showNameOnRanking)
    {
        this.Ra = ra;
        this.Type = UserType.Student;
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.Subjects = subjects;
        this.ShowNameOnRanking = showNameOnRanking;
        this.Type = type;
    }
    public string Ra { get; }
    public List<Subject> Subjects { get; }
    public bool ShowNameOnRanking { get; set; }
}