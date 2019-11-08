using Crypto;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Brotal.Extensions;

namespace Domain
{
    public class Block<T> where T : Entity
    {
        public string Id { get; private set; }
        public DateTime LocalCreatedAt { get; set; }
        public string PreviousBlockId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Signature { get; private set; }

        /// <summary>
        /// Public Key of the Originator
        /// </summary>
        public string Originator { get; set; }
        public T Data { get; set; }
        public string Type => typeof(T).Name;

        [JsonIgnore]
        public string GetPayload =>
            CreatedAt.Timestamp() +
            Originator            +
            Type                  +
            JsonSerializer.Serialize(Data);

        [JsonIgnore]
        public string GetContentForBlockHashing =>
            PreviousBlockId                +
            CreatedAt.Timestamp()          +
            Originator                     +
            Type                           +
            JsonSerializer.Serialize(Data) +
            Signature;


        public string Sign(string signatureKey)
        {
            var inputBytes = Encoding.UTF8.GetBytes(GetPayload);
            Signature = SignatureProvider.GetSignature(inputBytes, signatureKey);
            return Signature;
        }


        public string SetId()
        {
            var bytesToHash = Encoding.UTF8.GetBytes(GetContentForBlockHashing);
            using var hasher = SHA256.Create();
            var hashBytes = hasher.ComputeHash(bytesToHash);

            Id = Convert.ToBase64String(hashBytes);
            return Id;
        }

        public string ToJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
