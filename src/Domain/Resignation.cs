using System;
using Brotal.Extensions;
using LiteDB;
using Newtonsoft.Json;

namespace Domain
{
    public class Resignation : Entity
    {
        /// <summary>
        /// Public Key of the Employee
        /// </summary>
        public string Employee { get; set; }

        /// <summary>
        /// Public Key of the Organization
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Information related to the resignation
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Date of Resignation
        /// </summary>
        public DateTime EndDate { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public string Payload =>
            Employee     +
            Organization +
            Description  +
            EndDate.Timestamp();

        public string EmployeeSignature { get; set; }
    }
}
