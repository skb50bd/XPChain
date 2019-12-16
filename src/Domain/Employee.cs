using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Employee : Entity
    {
        /// <summary>
        /// Public Key of Employer Organization
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Public Key of the Employee
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// Designation of the Employee
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// Joining Date of the Employee
        /// </summary>
        [Display(Name = "Join Date")]
        public DateTime StartDate { get; set; }

        public string Payload =>
            (Organization +
             PublicKey +
             Designation +
             StartDate.TimeStamp()).ToBase64();

        public string EmployeeSignature { get; set; }

        /// <summary>
        /// Identification Signature is Generated using the Employee's
        /// Personal Information (name, birth date, identification number)
        /// serialized as: NAME_YYYYMMDD_IDENTIFICATION,
        /// and signed using employee's private key
        /// </summary>
        public string IdentificationSignature { get; set; }
    }
}
