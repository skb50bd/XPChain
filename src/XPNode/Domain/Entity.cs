using System;

namespace Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public Metadata Meta { get; set; }

        protected Entity()
        {
            Meta = new Metadata();
        }

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
