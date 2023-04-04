using System.Text.Json.Serialization;

namespace DiplomaProject.Models;

public record Response
{
    [JsonPropertyName("status")] 
    public bool Status { get; set; }
    [JsonPropertyName("result")]
    public Result Result { get; set; } = new();
}

