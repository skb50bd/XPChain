using System;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class ApplicationUser: IdentityUser
    {
        /// <summary>
        /// Full Legal Name 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Legal Date of Birth
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Social Security Number or National ID number
        /// </summary>
        public string IdentificationNumber { get; set; }

        public string Designation { get; set; }

        /// <summary>
        /// Public Key of the Employee
        /// </summary>
        public string PublicKey { get; set; }

        public string VerificationSignature { get; set; }
    }
}
