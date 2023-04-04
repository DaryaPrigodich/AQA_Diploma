using System.Text.Json.Serialization;

namespace DiplomaProject.Models;

public record Project
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("code")]
    public string Code { get; set; }
    [JsonPropertyName("access")] 
    public string? Access { get; set; } = "all";
}
