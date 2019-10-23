using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Project : Entity
    {
        public Guid OrganizationId { get; set; }
        public string Title { get; set; }
        public decimal Reward { get; set; }

        private Project()
        {
            Title = string.Empty;
        }

        public Project(
            Guid orgId, 
            string title, 
            decimal reward,
            Metadata meta) : base(meta)
        {
            OrganizationId = orgId;
            Title          = title;
            Reward         = reward;
        }
    }
}
