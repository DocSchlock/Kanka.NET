using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    /// <summary>
    /// class for the JSON top-level response from Kanka
    /// </summary>
    /// <typeparam name="T">Type the data payload contains - use collection for arrays</typeparam>
    public class KankaResponse<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("sync")]
        public DateTime? LastSync { get; set; }

        [JsonPropertyName("links")]
        public LinkBlock? Links { get; set; }

        [JsonPropertyName("meta")]
        public MetaBlock? Meta { get; set; }
    }

    /// <summary>
    /// small class to hold the Link payload top-level response
    /// </summary>
    public class LinkBlock
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

    /// <summary>
    /// small class to hold the meta payload response
    /// </summary>
    public class MetaBlock
    {
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("from")]
        public int From { get; set; }

        [JsonPropertyName("last_page")]
        public int LastPage { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("to")]
        public int To { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}