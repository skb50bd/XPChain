using System;

namespace XPNode.Domain
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public Guid WalletId { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
