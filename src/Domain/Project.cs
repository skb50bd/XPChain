using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Project : Entity
    {
        /// <summary>
        /// Public Key of the Organization
        /// </summary>
        public string Organization { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// Total Reward for the Project
        /// </summary>
        [Display(Name = "Experience Points")]
        public decimal TotalXp { get; set; }

        /// <summary>
        /// Any information related to the Project
        /// </summary>
        public string Description { get; set; }
    }
}
