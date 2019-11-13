using Newtonsoft.Json;
using System;
using LiteDB;

namespace Domain
{
    public class Block
    {
        public ObjectId Id { get; set; }
        public string Hash { get; set; }
        public string PreviousBlockHash { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Signature { get; set; }

        /// <summary>
        /// Public Key of the Originator
        /// </summary>
        public string Originator { get; set; }
        public string Data { get; set; }
        public string Type { get; set; }

        [BsonIgnore] [JsonIgnore]
        public string Payload =>
            CreatedAt.TimeStamp() +
            Originator +
            Type +
            Data;

        [BsonIgnore]
        [JsonIgnore]
        public string ContentForBlockHashing =>
            PreviousBlockHash            +
            CreatedAt.ToLongDateString() +
            Originator                   +
            Type                         +
            Data                         +
            Signature;
    }
}
