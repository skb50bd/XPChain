using System;
using LiteDB;
using Newtonsoft.Json;

namespace Domain
{
    public abstract class Entity
    {
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }
    }
}
