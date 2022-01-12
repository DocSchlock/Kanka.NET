using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Journal : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("character_id")]
        public int? CharacterId { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }
    }
}