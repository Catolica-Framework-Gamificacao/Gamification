using System.Drawing;
using Repository.Models.Database.User;

namespace Repository.Models.Database;

public class Student : BaseEntity
{
    public string Ra { get; }
    public ApplicationUser User { get; set; }
    public List<Subject>? Subjects { get; }
    public bool ShowNameOnRanking { get; set; }
    public double? Points { get; set; }
    
    public Student()
    {
        Subjects = new List<Subject>();
        ShowNameOnRanking = true;
        Points = 0;
    }
    public Student(string ra, ApplicationUser user, List<Subject> subjects, bool showNameOnRanking)
    {
        Ra = ra;
        User = user;
        Subjects = subjects;
        ShowNameOnRanking = showNameOnRanking;
        Points = 0;
    }

    public Student(string ra, ApplicationUser user)
    {
        Ra = ra ?? throw new ArgumentException("RA cannot be null");
        User = user;
        Subjects = new List<Subject>();
        ShowNameOnRanking = true;
        Points = 0;
    }
}