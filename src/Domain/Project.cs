namespace Domain
{
    public class Project : Entity
    {
        /// <summary>
        /// Public Key of the Organization
        /// </summary>
        public string Owner { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// Total Reward for the Project
        /// </summary>
        public decimal TotalExperiencePoints { get; set; }

        /// <summary>
        /// Any information related to the Project
        /// </summary>
        public string Description { get; set; }
    }
}
