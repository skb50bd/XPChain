using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Certificate: Entity
    {
        /// <summary>
        /// Subject of the Certificate
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Public Key of the Issuer Organization
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Public Key of the Certificate Owner
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Any related data related to the certificate
        /// </summary>
        public string Description { get; set; }
    }
}
