using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Block
    {
        [Display(Name = "Block ID")]
        public string Id { get; set; }

        [Display(Name = "Hash")]
        public string Hash { get; set; }

        [Display(Name = "Previous Block Hash")]
        public string PreviousBlockHash { get; set; }

        [Display(Name = "Created at")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Signature")]
        public string Signature { get; set; }

        /// <summary>
        /// Public Key of the Originator
        /// </summary>
        [Display(Name = "Block Owner")]
        public string Originator { get; set; }


        public string Data { get; set; }
        public string Type { get; set; }

        public string Payload =>
            CreatedAt.TimeStamp() +
            Originator +
            Type +
            Data;

        public string ContentForBlockHashing =>
            PreviousBlockHash +
            CreatedAt.ToLongDateString() +
            Originator +
            Type +
            Data +
            Signature;
    }
}
