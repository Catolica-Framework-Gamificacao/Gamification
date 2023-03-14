using System.Text.Json.Serialization;

namespace Api.Models;

public class BaseModel
{
    [JsonPropertyName("updateDate")]
    public DateTime? UpdateDate { get; set; } = DateTime.Now;

    [JsonPropertyName("insertDate")]
    public DateTime? InsertDate { get; set; } = DateTime.Now;
}