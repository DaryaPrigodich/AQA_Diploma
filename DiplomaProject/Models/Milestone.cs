using System.Text.Json.Serialization;

namespace DiplomaProject.Models;

public record Milestone
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
}
