using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Item : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("size")]
        public string Size { get; set; }
    }
}