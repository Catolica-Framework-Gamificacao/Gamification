using System.Text.Json.Serialization;

namespace Api.Models;

public class StudentModel : UserModel
{
    [JsonPropertyName("points")]
    public double? Points { get; set; }
    
    [JsonPropertyName("subjects")]
    public List<SubjectModel>? Subjects { get; set; }
    
}