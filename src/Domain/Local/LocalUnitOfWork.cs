using System.Text.Json.Serialization;
using LiteDB;

namespace Domain
{
    public class LocalUnitOfWork : Entity
    {
        /// <summary>
        /// Public Key of the Organization
        /// </summary>
        public string Organization { get; set; }
        
        public ObjectId ProjectId { get; set; }

        /// <summary>
        /// Public Key of the Employee that completed the Work
        /// </summary>
        public string Executor { get; set; }

        /// <summary>
        /// Keywords (comma separated) related to the Work
        /// e.g. HTML, Marketing, SEO, API, Dyeing, Designing, Crafting, etc.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Reward for the Unit-of-Work
        /// </summary>
        public decimal Xp { get; set; }
        public string Description { get; set; }
        
        public string Payload =>
            (Organization +
             ProjectId    +
             Executor     +
             Tags         +
             Xp           +
             Description).ToBase64();

        public string EmployeeSignature { get; set; }
    }
}
