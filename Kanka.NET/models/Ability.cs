using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Ability : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("ability_id")]
        public int? AbilityId { get; set; }

        [JsonPropertyName("charges")]
        public int? Charges { get; set; }

        [JsonPropertyName("abilities")]
        public int[]? Abilities { get; set; } // this may be wrong
    }
}