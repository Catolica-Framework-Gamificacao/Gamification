using System.Text.Json.Serialization;
using Api.Models.Enums;
using Repository.Models.Database;
using Repository.Models.Database.User;

namespace Api.Models;

public class TeacherModel : UserModel
{
    [JsonPropertyName("id")]
    public long? Id { get; }
    public List<StudentModel>? Students { get; set; }
    public List<SubjectModel>? Subjects { get; set; }

    public Teacher ToEntity()
    {
        UserType? type = UserType.Type ?? Enums.UserType.Teacher;
        
        var user = new ApplicationUser()
        {
            Name = this.Name ?? string.Empty,
            Email = this.Email ?? string.Empty,
            Password = this.Password ?? string.Empty,
            Type = UserTypeModel.GetLogicalByUserType(type),
            InsertDate = this.InsertDate,
            UpdateDate = this.UpdateDate
        };

        var students = new List<Student>();
        if (Students != null)
        {
            students = Students.Select(student => student.ToEntity()).ToList();
        }

        var subjects = new List<Subject>();
        if (Subjects != null)
        {
            subjects = Subjects.Select(subject => subject.ToEntity()).ToList();
        }
            

        return new Teacher()
        {
            User = user,
            Students = students,
            Subjects = subjects
        };
    }
}