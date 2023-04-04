using System.Text.Json.Serialization;

namespace DiplomaProject.Models;

public record Result
{
    [JsonPropertyName("id")] 
    public int Id { get; set; }
}
