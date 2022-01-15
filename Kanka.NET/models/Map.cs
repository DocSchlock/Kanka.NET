using Kanka.NET.models.interfaces;
using System.Text.Json.Serialization;

namespace Kanka.NET.models
{
    public class Map : EndpointAbstract, ICampaignRequired
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("location_id")]
        public int? LocationId { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("map_id")]
        public int? MapId { get; set; }

        [JsonPropertyName("grid")]
        public int Grid { get; set; }

        [JsonPropertyName("min_zoom")]
        public int MinZoom { get; set; }

        [JsonPropertyName("max_zoom")]
        public int MaxZoom { get; set; }

        [JsonPropertyName("initial_zoom")]
        public int InitialZoom { get; set; }

        [JsonPropertyName("center_marker_id")]
        public int? CenterMarkerId { get; set; }

        [JsonPropertyName("center_x")]
        public float? CenterX { get; set; }

        [JsonPropertyName("center_y")]
        public float? CenterY { get; set; }

        [JsonPropertyName("layers")]
        public MapLayer[] Layers { get; set; }

        [JsonPropertyName("groups")]
        public MapGroup[] Groups { get; set; }
    }

    public class MapLayer : ISubEndpoint
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("created_by")]
        public string? CreatedBy { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("updated_by")]
        public string? UpdatedBy { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("type_id")]
        public bool TypeId { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("map_id")]
        public int MapId { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("visibility")]
        public string Visibility { get; set; }

        public static string GetPath() => "map_layers";
    }

    public class MapGroup : ISubEndpoint
    {
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("created_by")]
        public string? CreatedBy { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("updated_by")]
        public string? UpdatedBy { get; set; }

        [JsonPropertyName("visibility")]
        public string Visibility { get; set; }

        [JsonPropertyName("map_id")]
        public int MapId { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("is_shown")]
        public bool IsShown { get; set; }

        public static string GetPath() => "map_groups";
    }

    public class MapMarker : ISubEndpoint
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("created_by")]
        public string? CreatedBy { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("updated_by")]
        public string? UpdatedBy { get; set; }

        [JsonPropertyName("visibility")]
        public string Visibility { get; set; }

        [JsonPropertyName("map_id")]
        public int MapId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("is_draggable")]
        public bool IsDraggable { get; set; }

        [JsonPropertyName("colour")]
        public string Colour { get; set; }

        [JsonPropertyName("circle_radius")]
        public int? CircleRadius { get; set; }

        [JsonPropertyName("custom_icon")]
        public string? CustomIcon { get; set; }

        [JsonPropertyName("custom_shape")]
        public string CustomShape { get; set; }

        [JsonPropertyName("entity_id")]
        public int? EntityId { get; set; }

        [JsonPropertyName("font_colour")]
        public string? FontColour { get; set; }

        [JsonPropertyName("icon")]
        public MapMarkerIcon Icon { get; set; } // 1: Marker, 2:Exclamation, 3:Interrogation, 4:Entity

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        [JsonPropertyName("opacity")]
        public int Opacity { get; set; }

        [JsonPropertyName("shape_id")]
        public MapMarkerShape ShapeId { get; set; }

        [JsonPropertyName("size_id")]
        public int SizeId { get; set; }

        [JsonPropertyName("polygon_style")]
        public string[] PolygonStyle { get; set; } // what is this?

        public static string GetPath() => "map_markers";
    }

    public enum MapMarkerIcon
    {
        Marker = 1,
        Exclamation = 2,
        Interrogation = 3,
        Entity = 4
    }

    public enum MapMarkerShape
    {
        Marker = 1,
        Label = 2,
        Circle = 3,
        Polygon = 4
    }
}