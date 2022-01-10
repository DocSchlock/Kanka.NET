using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class ResponseShell<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("sync")]
        public DateTime? LastSync { get; set; }

        [JsonPropertyName("links")]
        public ResponseLink? Links { get; set; }

        [JsonPropertyName("meta")]
        public MetaResponse? Meta { get; set; }
    }

    public class ResponseLink
    {
        [JsonPropertyName("first")]
        public string? FirstPath { get; set; }

        [JsonPropertyName("last")]
        public string? LastPath { get; set; }

        [JsonPropertyName("prev")]
        public string? PreviousPath { get; set; }

        [JsonPropertyName("next")]
        public string? NextPath { get; set; } //TODO: make sure GET code follows all non-null paths, probably need recursion
    }
}