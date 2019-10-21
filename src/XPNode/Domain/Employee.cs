using System;

namespace XPNode.Domain
{
    public class Employee : Entity
    {
        public string Name { get; set; } = string.Empty;
        public Guid WalletId { get; set; }
        public Guid OrganizationId { get; set; }

        public Employee(
            Guid walletId, 
            Guid organizationId, 
            Metadata meta) : base(meta)
        {
            WalletId = walletId;
            OrganizationId = organizationId;
        }

        public Employee(
            string name, 
            Guid walletId, 
            Guid organizationId, 
            Metadata meta) : base(meta)
        {
            Name = name;
            WalletId = walletId;
            OrganizationId = organizationId;
        }


    }
}
