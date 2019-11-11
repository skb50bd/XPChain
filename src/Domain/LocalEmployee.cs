using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LiteDB;

namespace Domain
{
    public class LocalEmployee : Entity
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Address { get; set; }

        public string Designation { get; set; }

        [Display(Name = "Public Key")]
        public string PublicKey { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Join date")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Social Security Number or National ID number
        /// </summary>
        [Display(Name = "Identification Number")]
        public string IdentificationNumber { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        [Display(Name = "Verification Message")]
        public string VerificationMessage =>
            (Name.ToUpperInvariant()        +
             " "                            +
             BirthDate.ToString("yyyyMMdd") +
             " "                            +
             IdentificationNumber).Replace(" ", "_");

        [Display(Name = "Verification Signature")]
        public string VerificationSignature { get; set; }

        [Display(Name = "Deployed to XPChain")]
        public bool IsDeployed { get; set; }
    }
}
