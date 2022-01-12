using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Race : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("race_id")]
        public int? RaceId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}