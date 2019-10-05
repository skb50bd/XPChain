using Brotal.Extensions;
using System;

namespace XPNode.Domain
{
    public class Metadata
    {
        public Guid Creator { get; set; }
        public string Timestamp { get; set; }

        public Metadata(Guid creator)
        {
            Creator = creator;
            Timestamp = DateTime.UtcNow.Timestamp();
        }
    }
}
