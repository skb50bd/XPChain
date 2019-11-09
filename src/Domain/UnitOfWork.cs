using System;

namespace Domain
{
    public class UnitOfWork : Entity
    {
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Public Key of the Employee that completed the Work
        /// </summary>
        public string Executor { get; set; }

        /// <summary>
        /// Keywords (comma separated) related to the Work
        /// e.g. HTML, Marketing, SEO, API, Dyeing, Designing, Crafting, etc.
        /// </summary>
        public string Tags { get; set; }


        public string Description { get; set; }

        /// <summary>
        /// Reward for the Unit-of-Work
        /// </summary>
        public decimal ExperiencePoint { get; set; }
    }
}
