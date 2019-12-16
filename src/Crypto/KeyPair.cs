using System.Security.Cryptography;

using static System.Convert;

namespace Crypto
{
    public class KeyPair
    {
        public byte[] PublicKeyAsByteArray;
        public string PublicKey
        {
            get => ToBase64String(PublicKeyAsByteArray);
            set => PublicKeyAsByteArray = FromBase64String(value);
        }

        public string PrivateKey
        {
            get => ToBase64String(PrivateKeyAsByteArray);
            set => PrivateKeyAsByteArray = FromBase64String(value);
        }

        public byte[] PrivateKeyAsByteArray;

        public static KeyPair NewKeyPair()
        {
            using var rsa = new RSACryptoServiceProvider();
            var publicKey = rsa.ExportRSAPublicKey();
            var privateKey = rsa.ExportRSAPrivateKey();

            return new KeyPair(publicKey, privateKey);
        }

        public KeyPair(byte[] publicKey, byte[] privateKey)
        {
            PublicKeyAsByteArray = publicKey;
            PrivateKeyAsByteArray = privateKey;
        }

        public KeyPair(string publicKey, string privateKey) :
            this(FromBase64String(publicKey),
                FromBase64String(privateKey))
        { }
    }
}