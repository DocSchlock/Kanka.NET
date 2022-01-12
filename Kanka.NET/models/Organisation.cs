using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Organisation : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("organisation_id")]
        public int OrganisationId { get; set; }

        [JsonPropertyName("members")]
        public OrganisationMember[]? Members { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }
    }

    public class OrganisationMember
    {
        // TODO this is sub endpoint to organization, uses a _ in the name
        [JsonPropertyName("organisation_id")]
        public int OrganisationId { get; set; }

        [JsonPropertyName("character_id")]
        public int CharacterId { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("pin_id")]
        public int PinId { get; set; } // 0, 1 if member is pinned to character, 2 if pinned to org, 3 if both

        [JsonPropertyName("status_id")]
        public int StatusId { get; set; } //0 for active, 1 for past, 2 for unknown

        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; } // boss
    }
}