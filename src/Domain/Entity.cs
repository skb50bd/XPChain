using System;
using LiteDB;

namespace Domain
{
    public abstract class Entity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
