namespace Domain.Local
{
    public class OrganizationOptions
    {
        //public RSAParameters PublicKeyRsa { get; set; }
        public string PublicKey { get; set; }

        //public RSAParameters PrivateKeyRsa { get; set; }
        public string PrivateKey { get; set; }

        public string Title { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
    }
}