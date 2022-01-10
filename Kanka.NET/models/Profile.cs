using Kanka.NET.models.enums;
using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Profile : ISupportedRESTCalls, IHumanize
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("avatar")]
        public string? Avatar { get; set; }

        [JsonPropertyName("avatar_thumb")]
        public string? AvatarThumb { get; set; }

        [JsonPropertyName("locale")]
        public string? Locale { get; set; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("date_format")]
        public string? DateFormat { get; set; }

        [JsonPropertyName("default_pagination")]
        public int DefaultPagination { get; set; }

        [JsonPropertyName("last_campaign_id")]
        public int LastCampaignId { get; set; }

        [JsonPropertyName("is_patreon")]
        public bool IsPatreon { get; set; }

        [JsonIgnore]
        public RestAction[] SupportedRESTCalls { get; } = new RestAction[1] { RestAction.GET };

        [JsonIgnore]
        public bool IsPluralized { get => false; }
    }
}