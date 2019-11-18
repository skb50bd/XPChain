using System;

namespace Domain
{
    public class Host : Entity
    {
        public string Address { get; set; }
        public int Port { get; set; }

        public string PublicKey { get; set; }

        public bool IsVerified { get; set; }

        public DateTime? LastSeen { get; set; } = null;
    }
}
