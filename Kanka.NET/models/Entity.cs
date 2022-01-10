using Kanka.NET.models.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanka.NET.models
{
    internal class Entity : IEntity
    {
        public int id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string entry { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string entry_parsed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string image { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string image_full { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string image_thumb { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid image_uuid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool is_private { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int entity_id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Tag[] tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime created_at { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int created_by { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime updated_at { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int updated_by { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsPluralized { get => throw new NotImplementedException(); }
    }
}