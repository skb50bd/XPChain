using Crypto;

using System;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Verification Message")]
        public string IdentificationMessage =>
            (Name.ToUpperInvariant() +
             " " +
             BirthDate.ToString("yyyyMMdd") +
             " " +
             IdentificationNumber)
           .Replace(" ", "_")
           .ToBase64();

        [Display(Name = "Identification Signature")]
        public string IdentificationSignature { get; set; }

        [Display(Name = "Verification Signature")]
        public string VerificationSignature { get; set; }

        [Display(Name = "Deployed to XPChain")]
        public bool IsDeployed { get; set; }

        public bool IsReadyToDeploy =>
            !string.IsNullOrWhiteSpace(IdentificationSignature)
         && !string.IsNullOrWhiteSpace(VerificationSignature);
    }

    public static class LocalEmployeeExtensions
    {
        public static string GetVerificationMessage(
            this LocalEmployee emp,
            string orgPublicKey) =>
            (orgPublicKey +
             emp.PublicKey +
             emp.Designation +
             emp.StartDate.TimeStamp()).ToBase64();

        public static bool Verify(
            this LocalEmployee emp,
            string orgPublicKey,
            string signature) =>
            SignatureProvider.Verify(
                emp.GetVerificationMessage(orgPublicKey),
                signature,
                emp.PublicKey);
    }
}
