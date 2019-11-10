using Crypto;
using Data.Persistence;
using Domain;
using Newtonsoft.Json;
using System;
using LiteDB;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            ILedgerRepository repo = new LiteDbLedgerRepository("test.db");

            var org1Keys = KeyPair.NewKeyPair();
            var org2Keys = KeyPair.NewKeyPair();
            var org2 = new Organization
            {
                Id = ObjectId.NewObjectId(),
                Title = "Brotal",
                Address = "Dhaka, Bangladesh",
                Email = "info@brotal.net",
                Phone = "SOME RANDOM PHONE #",
                PublicKey = org2Keys.PublicKey
            };

            var block = new Block
            {
                Data = JsonConvert.SerializeObject(org2),
                Type = typeof(Organization).Name,
                Originator = org1Keys.PublicKey,
                PreviousBlockHash = repo.GetLastBlockHash()
            };
            block.Sign(org1Keys.PrivateKey).SetHash();

            var res = repo.Insert(block);
            Console.WriteLine(res.PreviousBlockHash);
            Console.WriteLine(res.Hash);
            Console.WriteLine(res.Id.Increment);
        }
    }
}
