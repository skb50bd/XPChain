using System.Security.Cryptography;

namespace Crypto
{
    public class KeyPair
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }

        public static KeyPair NewKeyPair()
        {
            using var rsa        = new RSACryptoServiceProvider();
            var       publicKey  = rsa.ToJson(false);
            var       privateKey = rsa.ToJson(true);

            return new KeyPair
            {
                PublicKey  = publicKey,
                PrivateKey = privateKey
            };
        }
    }
}