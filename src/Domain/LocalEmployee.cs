using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class LocalEmployee : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }

        [Display(Name = "Public Key")]
        public string PublicKey { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Join date")] 
        public DateTime StartDate { get; set; }
        
        [Display(Name = "Deployed to XPChain")]
        public bool IsDeployed { get; set; }
    }
}
