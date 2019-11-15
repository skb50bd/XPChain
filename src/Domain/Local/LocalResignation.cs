using Crypto;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class LocalResignation : Entity
    {
        [Display(Name = "Employee's Public Key")]
        public string EmployeePublicKey { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Resignation")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Employee's Signature")]
        public string EmployeeSignature { get; set; }

        public bool IsReadyToDeploy =>
            !string.IsNullOrWhiteSpace(EmployeeSignature);

        [Display(Name = "Is Deployed")]
        public bool IsDeployed { get; set; }
    }

    public static class LocalResignationExtensions
    {
        public static string GetVerificationMessage(
            this LocalResignation resignation,
            string orgPublicKey) =>
            (orgPublicKey +
             resignation.EmployeePublicKey +
             resignation.Description +
             resignation.EndDate.TimeStamp()).ToBase64();

        public static bool Verify(
            this LocalResignation resignation,
            string orgPublicKey) =>
            SignatureProvider.Verify(
                resignation.GetVerificationMessage(orgPublicKey),
                resignation.EmployeeSignature,
                resignation.EmployeePublicKey);
    }
}
