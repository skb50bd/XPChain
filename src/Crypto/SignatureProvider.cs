using System.Security.Cryptography;

using static System.Convert;
using static System.Text.Encoding;

namespace Crypto
{
    public static class SignatureProvider
    {

        /// <summary>
        /// Gets RSA signature of the input data
        /// </summary>
        /// <param name="data">The data as byte array</param>
        /// <param name="privateKey">RSA private key as byte array</param>
        /// <returns>Signature byte array</returns>
        public static byte[] GetSignatureAsByteArray(byte[] data, byte[] privateKey)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.ImportRSAPrivateKey(privateKey, out _);
            return rsa.SignData(data, new SHA1CryptoServiceProvider());
        }

        /// <summary>
        /// Gets RSA signature of the input data
        /// </summary>
        /// <param name="data">The data as string</param>
        /// <param name="privateKey">RSA private key as JSON string</param>
        /// <returns>Signature as base64 string</returns>
        public static string GetSignature(string data, string privateKey)
        {
            var dataArray = UTF8.GetBytes(data.Trim());
            var privateKeyArray = FromBase64String(privateKey.Trim());
            var signature = GetSignatureAsByteArray(dataArray, privateKeyArray);

            return ToBase64String(signature);
        }

        /// <summary>
        /// Verify if a RSA Signature is valid against the data and public key
        /// </summary>
        /// <param name="plainText">Message to as byte array</param>
        /// <param name="signature">Signature of the Message as byte array</param>
        /// <param name="publicKey">Public Key of the Signer as byte array</param>
        /// <returns></returns>
        public static bool Verify(
            byte[] plainText,
            byte[] signature,
            byte[] publicKey)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.ImportRSAPublicKey(publicKey, out _);

            return rsa.VerifyData(
                plainText,
                new SHA1CryptoServiceProvider(),
                signature);
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
            string publicKey)
        {
            var plainTextArray = UTF8.GetBytes(plainText.Trim());
            var signatureArray = FromBase64String(signature.Trim());
            var publicKeyArray = FromBase64String(publicKey.Trim());

            return Verify(plainTextArray, signatureArray, publicKeyArray);
        }
    }
}
