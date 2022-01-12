using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Location : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("location_id")]
        public int? LocationId { get; set; }

        [JsonPropertyName("entity_id")]
        public int EntityId { get; set; }

        [JsonPropertyName("tags")]
        public int[]? Tags { get; set; }

        [JsonPropertyName("parent_location_id")]
        public int ParentLocationId { get; set; }

        [JsonPropertyName("map")]
        public string? Map { get; set; }

        [JsonPropertyName("is_map_private")]
        public int IsMapPrivate { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}