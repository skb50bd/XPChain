using System;
using System.Collections.Generic;
using System.Linq;

namespace XPNode.Domain
{
    public class Project : Entity
    {
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public string Title { get; set; }
        public List<PieceOfWork> WorkPieces { get; set; }
        public decimal Reward { get; set; }

        public bool IsComplete =>
            (WorkPieces?.Sum(w => w.Weight) ?? 0M) >= 1M;
    }
}
