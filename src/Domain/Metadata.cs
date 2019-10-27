using Brotal.Extensions;
using System;

namespace Domain
{
    public class Metadata
    {
        public Guid Creator { get; set; }
        public string Timestamp { get; set; }

        //internal Metadata()
        //{
        //    Timestamp = string.Empty;
        //}

        //public Metadata(Guid creator)
        //{
        //    Creator = creator;
        //    Timestamp = DateTime.UtcNow.Timestamp();
        //}
    }
}
