using System.Text.Json.Serialization;
using Repository.Models.Database;

namespace Api.Models;

public class SubjectModel : BaseModel
{
    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("students")]
    public List<StudentModel>? Students { get; set; }
    [JsonPropertyName("teacher")]
    public long Teacher { get; set; }

    public static List<SubjectModel> FromDatabaseList(List<Subject> subjects)
    {
        return subjects.Select(subject => Load(subject)).ToList();
    }

    public static SubjectModel Load(Subject subject)
    {
        return new SubjectModel()
        {
            Uuid = subject.Uuid,
            Name = subject.Name,
            InsertDate = subject.InsertDate,
            UpdateDate = subject.UpdateDate
        };
    }

    public Subject ToEntity()
    {
        
        return new Subject()
        {
            Uuid = Uuid ?? string.Empty,
            Name = Name,
            InsertDate = null,
            UpdateDate = null,
            Teacher = new Teacher()
            {
                Id = Teacher
            }
        };
    }
}