using Repository.Models.Database.User;

namespace Repository.Models.Database;

public class Student : BaseEntity
{
    public Student() {}
    public Student(string ra, ApplicationUser user, List<Subject> subjects, bool showNameOnRanking)
    {
        this.Ra = ra;
        this.User = user;
        this.Subjects = subjects;
        this.ShowNameOnRanking = showNameOnRanking;
    }
    public string Ra { get; }
    
    public ApplicationUser User { get; set; }
    public List<Subject>? Subjects { get; }
    public bool ShowNameOnRanking { get; set; }
    
    public double? points { get; set; }
}