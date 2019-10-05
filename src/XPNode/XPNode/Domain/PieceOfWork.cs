using System;

namespace XPNode.Domain
{
    public class PieceOfWork : Entity
    {
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }

        public Guid Executor { get; set; }

        private decimal _weight;
        public decimal Weight
        {
            get => _weight;
            set
            {
                if (value <= 1M) _weight = value;
            }
        }
    }
}
