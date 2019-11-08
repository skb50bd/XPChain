using System;
using System.Security.Cryptography;

namespace Crypto
{
    public static class SignatureProvider
    {
        /// <summary>
        /// Gets RSA signature of the input data
        /// </summary>
        /// <param name="data">The data as byte array</param>
        /// <param name="privateKey">RSA private key as XML string</param>
        /// <returns>Signature as base64 string</returns>
        public static string GetSignature(byte[] data, string privateKey)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.FromJson(privateKey);

            var signature = rsa.SignData(data, new SHA1CryptoServiceProvider());

            return Convert.ToBase64String(signature);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText">Message to as byte array</param>
        /// <param name="signature">Signature of the Message as byte array</param>
        /// <param name="publicKey">Public Key of the Signer</param>
        /// <returns></returns>
        public static bool Verify(
            byte[] plainText, 
            byte[] signature, 
            string publicKey)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.FromJson(publicKey);

            return rsa.VerifyData(plainText, new SHA1CryptoServiceProvider(), signature);
        }
    }
}
