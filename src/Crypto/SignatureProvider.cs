using System;
using System.Security.Cryptography;
using System.Text;

namespace Crypto
{
    public static class SignatureProvider
    {
        /// <summary>
        /// Gets RSA signature of the input data
        /// </summary>
        /// <param name="data">The data as byte array</param>
        /// <param name="privateKey">RSA private key as JSON string</param>
        /// <returns>Signature as base64 string</returns>
        public static string GetSignature(byte[] data, string privateKey)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.FromJson(privateKey);

            var signature = rsa.SignData(data, new SHA1CryptoServiceProvider());

            return Convert.ToBase64String(signature);
        }

        /// <summary>
        /// Gets RSA signature of the input data
        /// </summary>
        /// <param name="data">The data as string</param>
        /// <param name="privateKey">RSA private key as JSON string</param>
        /// <returns>Signature as base64 string</returns>
        public static string GetSignature(string data, string privateKey) => 
            GetSignature(Encoding.UTF8.GetBytes(data), privateKey);

        /// <summary>
        /// Verify if a RSA Signature is valid against the data and public key
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


        /// <summary>
        /// Verify if a RSA Signature is valid against the data and public key
        /// </summary>
        /// <param name="plainText">Message to as string</param>
        /// <param name="signature">Signature of the Message as string</param>
        /// <param name="publicKey">Public Key of the Signer</param>
        public static bool Verify(
            string plainText,
            string signature,
            string publicKey) =>
            Verify(
                Encoding.UTF8.GetBytes(plainText),
                Convert.FromBase64String(signature), 
                publicKey
            );
    }
}
