using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    /// <summary>
    /// Class for the Character Endpoint
    /// </summary>
    public class Character : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("is_personality_visible")]
        public bool IsPersonalityVisible { get; set; }

        [JsonPropertyName("is_template")]
        public bool IsTemplate { get; set; }

        [JsonPropertyName("entity_id")]
        public int EntityId { get; set; }

        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("age")]
        public string? Age { get; set; }

        [JsonPropertyName("sex")]
        public string? Sex { get; set; }

        [JsonPropertyName("pronouns")]
        public string? Pronouns { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("families")]
        public int[]? Families { get; set; }

        [JsonPropertyName("races")]
        public int[]? Races { get; set; }

        [JsonPropertyName("tags")]
        public int[]? Tags { get; set; }

        [JsonPropertyName("is_dead")]
        public bool IsDead { get; set; }

        [JsonPropertyName("traits")]
        public CharacterTraits[]? Traits { get; set; }
    }

    /// <summary>
    /// Class for Character Traits
    /// </summary>
    public class CharacterTraits
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("entry")]
        public string? Entry { get; set; }

        [JsonPropertyName("section")]
        public string? Section { get; set; }

        [JsonPropertyName("section_id")]
        public int SectionId { get; set; }

        [JsonPropertyName("default_order")]
        public int DefaultOrder { get; set; }
    }
}