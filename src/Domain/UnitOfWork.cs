using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UnitOfWork : Entity
    {
        /// <summary>
        /// Public Key of the Organization
        /// </summary>
        public string Organization { get; set; }

        [Display(Name = "Project ID")]
        public string ProjectId { get; set; }

        /// <summary>
        /// Public Key of the Employee that completed the Work
        /// </summary>
        [Display(Name = "Executor's Public Key")]
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
        public decimal Xp { get; set; }

        public string Payload =>
            (Organization +
             ProjectId +
             Executor +
             Tags +
             Xp.ToString("0.######") +
             Description).ToBase64();

        [Display(Name = "Employee's Signature")]
        public string EmployeeSignature { get; set; }
    }
}
