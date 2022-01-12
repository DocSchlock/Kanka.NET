using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    /// <summary>
    /// Class for the Campaign endpoint
    /// </summary>
    public class Campaign : IHumanize
    {
        public bool IsPluralized { get => true; }

        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("entry")]
        public string Entry { get; set; }

        [JsonPropertyName("entry_parsed")]
        public string EntryParsed { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("image_full")]
        public string ImageFull { get; set; }

        [JsonPropertyName("image_thumb")]
        public string ImageThumb { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("visibility")]
        public string Visibility { get; set; }

        [JsonPropertyName("visibility_id")]
        public int VisibilityID { get; set; }

        [JsonPropertyName("members")]
        public CampaignMembers[] Members { get; set; }

        [JsonPropertyName("boosted")]
        public bool Boosted { get; set; }

        [JsonPropertyName("superboosted")]
        public bool SuperBoosted { get; set; }
    }

    /// <summary>
    /// small class for the members of a Campaign
    /// </summary>
    public class CampaignMembers
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
    }
}