using System;

namespace Domain
{
    public class Organization : Entity
    {
        public Guid Owner { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }


        private Organization()
        {
            Name = string.Empty;
        }

        public Organization(
            Guid owner, 
            string name, 
            decimal balance,
            Metadata meta) : base(meta)
        {
            Owner = owner;
            Name = name;
            Balance = balance;
        }
    }
}
