using Repository.Models.Database.User;
using Repository.Models.Enums;

namespace Repository.Models.Database;

public class Teacher : ApplicationUser
{
    public Teacher() {}
    public Teacher(List<Subject> subjects, List<Student> students, ApplicationUser user)
    {
        Subjects = subjects;
        Students = students;
        Name = user.Name;
        Email = user.Email;
        Password = user.Password;
        Type = UserType.Teacher;
    }

    public List<Student> Students { get; }
    
    public List<Subject> Subjects { get; }
}