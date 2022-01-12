using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Family : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("family_id")]
        public int FamilyId { get; set; }

        [JsonPropertyName("members")]
        public int[]? Members { get; set; } // these are character ids

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("tags")]
        public int[]? Tags { get; set; }

        [JsonPropertyName("entity_id")]
        public int EntityId { get; set; }

        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }
    }
}