using LiteDB;
using System;

namespace Domain
{
    public class Host
    {
        public ObjectId Id { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }

        public string PublicKey { get; set; }

        public DateTime? LastSeen { get; set; } = null;
    }
}
