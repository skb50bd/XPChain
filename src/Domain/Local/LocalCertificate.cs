using Crypto;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class LocalCertificate : Entity
    {
        public string Title { get; set; }

        [Display(Name = "Receiver's Public Key")]
        public string ReceiverPublicKey { get; set; }

        public string Description { get; set; }

        [Display(Name = "Receiver's Signature")]
        public string ReceiverSignature { get; set; }


        public bool IsReadyToDeploy =>
            !string.IsNullOrWhiteSpace(ReceiverSignature);

        [Display(Name = "Is Deployed")]
        public bool IsDeployed { get; set; }
    }

    public static class LocalCertificateExtensions
    {
        public static string GetVerificationMessage(
            this LocalCertificate cert,
            string                orgPublicKey) =>
            (orgPublicKey           +
             cert.ReceiverPublicKey +
             cert.Title             +
             cert.Description).ToBase64();

        public static bool Verify(
            this LocalCertificate cert,
            string orgPublicKey) =>
            SignatureProvider.Verify(
                cert.GetVerificationMessage(orgPublicKey),
                cert.ReceiverSignature,
                cert.ReceiverPublicKey);
    }
}
