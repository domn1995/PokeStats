using System.Text.Json.Serialization;

namespace PokeStats.Lib;

public record Pokemon
{
    [JsonPropertyName("base_experience")]
    public int BaseExperience { get; init; }

    [JsonPropertyName("height")]
    public int Height { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("is_default")]
    public bool IsDefault { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = "";

    [JsonPropertyName("weight")]
    public int Weight { get; set; }
}