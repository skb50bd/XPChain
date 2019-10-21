using System;

namespace XPNode.Domain
{
    public class PieceOfWork : Entity
    {
        public Guid ProjectId { get; set; }

        public Guid ExecutorId { get; set; }

        private decimal _weight;
        public decimal Weight
        {
            get => _weight;
            set
            {
                if (value <= 1M) _weight = value;
            }
        }

        public PieceOfWork(
            Guid projectId, 
            Guid executorId, 
            decimal weight,
            Metadata meta): base(meta)
        {
            ProjectId = projectId;
            ExecutorId = executorId;
            Weight = weight;
        }
    }
}
