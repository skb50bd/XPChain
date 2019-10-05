using System;

namespace XPNode.Domain
{
    public class Organization : Entity
    {
        public Guid Owner { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
