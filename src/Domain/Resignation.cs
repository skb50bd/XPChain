using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Resignation : Entity
    {
        /// <summary>
        /// Public Key of the Employee
        /// </summary>
        public string Employee { get; set; }

        /// <summary>
        /// Public Key of the Organization
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Information related to the resignation
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Date of Resignation
        /// </summary>
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public string Payload =>
            (Organization +
             Employee +
             Description +
             EndDate.TimeStamp()).ToBase64();

        [Display(Name = "Employee's Signature")]
        public string EmployeeSignature { get; set; }
    }
}
