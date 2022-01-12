using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Note : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("is_pinned")]
        public int IsPinned { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("note_id")]
        public int? NoteId { get; set; }
    }
}