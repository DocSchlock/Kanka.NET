namespace Kanka.NET.models.interfaces
{
    internal interface IEntity : IHumanize
    {
        int id { get; set; }
        string name { get; set; }
        string entry { get; set; }
        string entry_parsed { get; set; }
        string image { get; set; }
        string image_full { get; set; }
        string image_thumb { get; set; }
        Guid image_uuid { get; set; }
        bool is_private { get; set; }
        int entity_id { get; set; }
        Tag[] tags { get; set; } // there's an issue here, since TAG mostly inherits from Entity itself
        DateTime created_at { get; set; }
        int created_by { get; set; }
        DateTime updated_at { get; set; }
        int updated_by { get; set; }
    }
}