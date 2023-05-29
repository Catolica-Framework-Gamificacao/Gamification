using Repository.Models.Database.User;

namespace Repository.Models.Database;

public class Teacher : BaseEntity
{
    public ApplicationUser User { get; set; }
    public List<Student>? Students { get; set; }
    public List<Subject>? Subjects { get; set; }

    public Teacher()
    {
        Students = new List<Student>();
        Subjects = new List<Subject>();
    }
    public Teacher(List<Subject> subjects, List<Student> students, ApplicationUser user)
    {
        Subjects = subjects;
        Students = students;
        User = user;
    }

    public Teacher(ApplicationUser user)
    {
        User = user;
        Students = new List<Student>();
        Subjects = new List<Subject>();
    }
}