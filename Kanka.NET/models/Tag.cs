using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Tag : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("tag_id")]
        public int? TagId { get; set; }

        [JsonPropertyName("colour")]
        public string Colour { get; set; }

        [JsonPropertyName("entities")]
        public int[]? Entities { get; set; }
    }
}