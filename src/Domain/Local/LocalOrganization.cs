using Crypto;

namespace Domain
{
    public class LocalOrganization : Entity
    {
        public string PublicKey { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string VerificationSignature { get; set; }

        public bool IsReadyToDeploy =>
            !string.IsNullOrWhiteSpace(VerificationSignature);
        
        public bool IsDeployed { get; set; }
    }

    public static class LocalOrganizationExtensions
    {
        public static string GetVerificationMessage(this LocalOrganization org) =>
            (org.PublicKey +
             org.Title +
             org.Address +
             org.Email +
             org.Phone).ToBase64();

        public static bool Verify(this LocalOrganization org) =>
            SignatureProvider.Verify(
                org.GetVerificationMessage(),
                org.VerificationSignature,
                org.PublicKey);
    }
}
