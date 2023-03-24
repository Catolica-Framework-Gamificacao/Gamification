using Repository.Models.Database.User;

namespace Repository.Models.Database;

public class Teacher : BaseEntity
{
    public Teacher() {}
    public Teacher(List<Subject> subjects, List<Student> students, ApplicationUser user)
    {
        Subjects = subjects;
        Students = students;
        User = user;
    }
    
    public ApplicationUser User { get; set; }

    public List<Student> Students { get; }
    
    public List<Subject> Subjects { get; }
}