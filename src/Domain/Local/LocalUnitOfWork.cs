using System.ComponentModel.DataAnnotations;
using Crypto;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class LocalUnitOfWork : Entity
    {
        [Display(Name = "Project")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProjectId { get; set; }

        [Display(Name = "Executor ID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ExecutorId { get; set; }

        /// <summary>
        /// Public Key of the Employee that completed the Work
        /// </summary>
        [Display(Name = "Executor Pub. Key")]
        public string ExecutorPublicKey { get; set; }

        /// <summary>
        /// Keywords (comma separated) related to the Work
        /// e.g. HTML, Marketing, SEO, API, Dyeing, Designing, Crafting, etc.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Reward for the Unit-of-Work
        /// </summary>
        [Display(Name = "Experience Points")]
        public decimal Xp { get; set; }

        public string Description { get; set; }

        [Display(Name = "Executor's Signature")]
        public string EmployeeSignature { get; set; }


        public bool IsReadyToDeploy =>
            !string.IsNullOrWhiteSpace(EmployeeSignature);

        /// <summary>
        /// Indicates if the UoW is deployed to XPChain
        /// </summary>
        /// <value></value>
        [Display(Name = "Is Deployed")]
        public bool IsDeployed { get; set; }
    }

    public static class LocalUnitOfWorkExtensions
    {
        public static string GetVerificationMessage(
            this LocalUnitOfWork uow, 
            string orgPublicKey)
        {
            var output = orgPublicKey                +
                         uow.ProjectId               +
                         uow.ExecutorPublicKey       +
                         uow.Tags                    +
                         uow.Xp.ToString("0.######") +
                         uow.Description;

            return output.ToBase64();
        }

        public static bool Verify(
            this LocalUnitOfWork uow, 
            string orgPublicKey) =>
            SignatureProvider.Verify(
                uow.GetVerificationMessage(orgPublicKey),
                uow.EmployeeSignature,
                uow.ExecutorPublicKey);
    }
}
