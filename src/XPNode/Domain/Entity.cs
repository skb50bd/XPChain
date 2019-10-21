using System;

namespace XPNode.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public Metadata Meta { get; set; }

        protected Entity(Guid id, Metadata meta)
        {
            Id = id;
            Meta = meta;
        }

        protected Entity(Metadata meta)
        {
            Id = Guid.NewGuid();
            Meta = meta;
        }
    }
}
