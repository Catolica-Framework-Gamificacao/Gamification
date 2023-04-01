using System.Text.Json.Serialization;

namespace Api.Models;

public class SubjectModel : BaseModel
{
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("students")]
    public List<StudentModel>? Students { get; set; }
    [JsonPropertyName("teacher")]
    public TeacherModel Teacher { get; set; }
    
}