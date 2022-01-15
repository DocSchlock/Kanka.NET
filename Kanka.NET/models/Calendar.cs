using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Calendar : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("parameters")]
        public string? Parameters { get; set; }

        [JsonPropertyName("months")]
        public CalendarMonths[]? Months { get; set; }

        [JsonPropertyName("start_offset")]
        public int StartOffset { get; set; }

        [JsonPropertyName("weekdays")]
        public string[]? Weekdays { get; set; }

        [JsonPropertyName("years")]
        public Dictionary<string, string>[]? Years { get; set; } // this may not work

        [JsonPropertyName("seasons")]
        public CalendarSeason[]? Seasons { get; set; }

        [JsonPropertyName("moons")]
        public CalendarMoon[]? Moons { get; set; }

        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }

        [JsonPropertyName("has_leap_year")]
        public bool HasLeapYear { get; set; }

        [JsonPropertyName("leap_year_amount")]
        public int LeapYearAmount { get; set; }

        [JsonPropertyName("leap_year_month")]
        public int LeapYearMonth { get; set; }

        [JsonPropertyName("leap_year_offset")]
        public int LeapYearOffset { get; set; }

        [JsonPropertyName("leap_year_start")]
        public int LeapYearStart { get; set; }
    }

    public class CalendarMonths
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class CalendarSeason
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("month")]
        public int Month { get; set; }

        [JsonPropertyName("day")]
        public int Day { get; set; }
    }

    public class CalendarMoon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("fullmoon")]
        public string Fullmoon { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("colour")]
        public string Colour { get; set; }
    }
}