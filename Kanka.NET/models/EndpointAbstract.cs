using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public abstract class EndpointAbstract
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("entry")]
        public string? Entry { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("image_full")]
        public string? ImageFull { get; set; }

        [JsonPropertyName("image_thumb")]
        public string? ImageThumb { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("created_by")]
        public string? CreatedBy { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("updated_by")]
        public string? UpdatedBy { get; set; }

        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("has_custom_image")]
        public bool HasCustomImage { get; set; }

        [JsonPropertyName("tags")]
        public int[]? Tags { get; set; }

        [JsonPropertyName("entity_id")]
        public int EntityId { get; set; }
    }
}