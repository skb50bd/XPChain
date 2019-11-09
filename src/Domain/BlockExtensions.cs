using Crypto;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public static class BlockExtensions
    {
        public static string GenerateSignature(this Block block, string signatureKey)
        {
            return SignatureProvider.GetSignature(block.Payload, signatureKey);
        }

        public static Block Sign(this Block block, string signatureKey)
        {
            block.Signature = block.GenerateSignature(signatureKey);
            return block;
        }

        public static string CalculateHash(this Block block)
        {
            var bytesToHash = Encoding.UTF8.GetBytes(block.ContentForBlockHashing);
            using var hasher = SHA256.Create();
            var hashBytes = hasher.ComputeHash(bytesToHash);

            return Convert.ToBase64String(hashBytes);
        }

        public static Block SetHash(this Block block)
        {
            block.Hash = block.CalculateHash();
            return block;
        }


        public static bool VerifySignature(this Block block) =>
        SignatureProvider.Verify(
            block.Payload,
            block.Signature,
            block.Originator);

        public static bool VerifyHash(this Block block) =>
            block.Hash == block.CalculateHash();

        public static bool Validate(this Block block)
        {
            if (!block.VerifySignature() || !block.VerifyHash()) return false;

            if (block.Type == typeof(Certificate).Name)
            {
                var cert = block.Data.FromJson<Certificate>();
                if (cert.Issuer != block.Originator) return false;
            }
            else if (block.Type == typeof(Employee).Name)
            {

            }
            else if (block.Type == typeof(Organization).Name)
            {

            }
            else if (block.Type == typeof(Project).Name)
            {

            }
            else if (block.Type == typeof(Resignation).Name)
            {

            }
            else if (block.Type == typeof(UnitOfWork).Name)
            {

            }
            else return false;

            return true;
        }
    }
}
