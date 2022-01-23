using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Entity : EndpointAbstract
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("child_id")]
        public int ChildId { get; set; }

        [JsonPropertyName("campaign_id")]
        public int CampaignId { get; set; }

        [JsonPropertyName("is_attributes_private")]
        public bool IsAttributesPrivate { get; set; }

        [JsonPropertyName("tooltip")]
        public string? Tooltip { get; set; }

        [JsonPropertyName("header_image")]
        public string? HeaderImage { get; set; }

        [JsonPropertyName("image_uuid")]
        public Guid? ImageUUID { get; set; } // superboosted
    }
}