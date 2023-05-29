using System.Text.Json.Serialization;
using Repository.Models.Database;

namespace Api.Models;

public class StudentModel : UserModel
{
    [JsonPropertyName("ra")]
    public string Ra { get; set; }
    
    [JsonPropertyName("points")]
    public double? Points { get; set; }
    
    [JsonPropertyName("subjects")]
    public List<SubjectModel>? Subjects { get; set; }

    public Student ToEntity()
    {
        return new Student();
    }

}