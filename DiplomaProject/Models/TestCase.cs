using System.Text.Json.Serialization;

namespace DiplomaProject.Models;

public record TestCase
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("priority")]
    public int Priority { get; set; }
}
