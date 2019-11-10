using System;
using Brotal.Extensions;
using LiteDB;
using Newtonsoft.Json;

namespace Domain
{
    public class Employee : Entity
    {
        public string Organization { get; set; }
        public string PublicKey { get; set; }
        public string Designation { get; set; }
        public DateTime StartDate { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public string Payload =>
            Organization +
            PublicKey    +
            Designation  +
            StartDate.Timestamp();
        public string EmployeeSignature { get; set; }

        /// <summary>
        /// Identification Signature is Generated using the Employee's
        /// Personal Information (name, birth date, identification number)
        /// serialized as: NAME_YYYYMMDD_IDENTIFICATION,
        /// and signed using employee's private key
        /// </summary>
        public string IdentificationSignature { get; set; }
    }
}
