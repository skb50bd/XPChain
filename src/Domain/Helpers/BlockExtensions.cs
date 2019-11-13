using Crypto;
using System.Security.Cryptography;

namespace Domain
{
    public static class BlockExtensions
    {
        public static string GenerateSignature(
            this Block block, 
            string signatureKey) =>
            SignatureProvider.GetSignature(
                block.Payload, 
                signatureKey);

        public static Block Sign(
            this Block block, 
            string signatureKey)
        {
            block.Signature = block.GenerateSignature(signatureKey);
            return block;
        }

        public static string CalculateHash(this Block block)
        {
            var bytesToHash = block.ContentForBlockHashing.ToByteArray();
            using var hasher = SHA256.Create();
            var hashBytes = hasher.ComputeHash(bytesToHash);

            return hashBytes.ToBase64();
        }

        public static Block SetHash(this Block block)
        {
            block.Hash = block.CalculateHash();
            return block;
        }

        public static bool VerifySignature(
            this Block block) =>
            SignatureProvider.Verify(
                block.Payload,
                block.Signature,
                block.Originator);

        public static bool VerifyHash(this Block block) =>
            block.Hash == block.CalculateHash();

        public static bool Validate(this Block block)
        {
            if (string.IsNullOrWhiteSpace(block.Originator)) return false;
            if (!block.VerifySignature() || !block.VerifyHash()) return false;

            if (block.Type == typeof(Certificate).Name)
            {
                var cert = block.Data.FromJson<Certificate>();
                var isValid = SignatureProvider.Verify(
                                  cert.Payload,
                                  cert.OwnerSignature,
                                  cert.Owner)
                           && cert.Issuer == block.Originator;
                if (!isValid) return false;
            }
            else if (block.Type == typeof(Employee).Name)
            {
                var employee = block.Data.FromJson<Employee>();
                var isSameOriginator =
                    block.Originator == employee.Organization;
                var isValidSignature = SignatureProvider.Verify(
                    employee.Payload,
                    employee.EmployeeSignature,
                    employee.PublicKey);

                if (!isSameOriginator || !isValidSignature) return false;
            }
            else if (block.Type == typeof(Organization).Name)
            {
                var organization = block.Data.FromJson<Organization>();
                var isValid =
                    string.IsNullOrWhiteSpace(block.PreviousBlockHash)
                        ? block.Originator == organization.PublicKey
                        : block.Originator != organization.PublicKey;
                if (!isValid) return false;
            }
            else if (block.Type == typeof(Project).Name)
            {
                var project = block.Data.FromJson<Project>();
                var isValid = block.Originator == project.Organization;
                if (!isValid) return false;
            }
            else if (block.Type == typeof(Resignation).Name)
            {
                var resignation = block.Data.FromJson<Resignation>();
                var isValid = block.Originator == resignation.Organization
                           && SignatureProvider.Verify(
                                  resignation.Payload,
                                  resignation.EmployeeSignature,
                                  resignation.Employee);
                if (!isValid) return false;
            }
            else if (block.Type == typeof(UnitOfWork).Name)
            {
                var unitOfWork = block.Data.FromJson<UnitOfWork>();
                var isValid = block.Originator == unitOfWork.Organization
                           && SignatureProvider.Verify(
                                  unitOfWork.Payload,
                                  unitOfWork.EmployeeSignature,
                                  unitOfWork.Executor);
                if (!isValid) return false;
            }
            else return false;

            return true;
        }
    }
}
