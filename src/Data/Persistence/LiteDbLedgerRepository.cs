using Domain;
using LiteDB;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Persistence
{
    public class LiteDbLedgerRepository : ILedgerRepository
    {
        #region Properties

        /// <summary>
        /// Get database instance
        /// </summary>
        private LiteDatabase Db { get; }

        private LiteCollection<Block> Collection =>
            Db.GetCollection<Block>("ledger");

        #endregion

        #region Ctor

        public LiteDbLedgerRepository(
            IOptionsMonitor<LiteSettings> settings,
            BsonMapper mapper = null)
        {
            if (mapper is null) mapper = BsonMapper.Global;
            Db = new LiteDatabase(settings.CurrentValue.Ledger, mapper);
            Collection.EnsureIndex(b => b.Type);
            Collection.EnsureIndex(b => b.Hash);
            Collection.EnsureIndex(b => b.PreviousBlockHash);
        }

        public LiteDbLedgerRepository(
            string connectionString)
        {
            Db = new LiteDatabase(connectionString);
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool cleanAll)
        {
            Db.Dispose();
        }

        public string GetLastBlockHash() => 
            GetLastBlock()?.Hash;

        public Block GetLastBlock() =>
            Collection.FindOne(Query.All(Query.Descending));

        public int GetChainLength() =>
            Collection.Count(Query.All());

        public Block GetGenesisBlock() =>
            Collection.FindOne(b => b.PreviousBlockHash == null);

        public Block GetNextBlock(string currentBlockHash) =>
            Collection.FindOne(b => b.PreviousBlockHash == currentBlockHash);

        public Block Insert(Block item)
        {
            var lastBlockHash = GetLastBlockHash();
            if (string.IsNullOrWhiteSpace(item.PreviousBlockHash))
                item.PreviousBlockHash = lastBlockHash;
            
            if(item.PreviousBlockHash != lastBlockHash) 
                throw new HashMismatchException();
            
            if (!item.Validate()) throw new InvalidBlockException();

            var id = Collection.Insert(item);
            return GetById(id);
        }

        public IEnumerable<Block> GetAll()
        {
            return Collection.FindAll();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return Collection.Find(b => b.Type == typeof(T).Name)
                             .Select(b => JsonConvert.DeserializeObject<T>(b.Data));
        }

        public T GetById<T>(ObjectId id)
        {
            var strId = id.ToString();
            return JsonConvert.DeserializeObject<T>(
                Collection.FindOne(
                    b => b.Type == typeof(T).Name
                         && b.Data.Contains(strId))
                          .Data);
        }

        public Block GetById(ObjectId id) =>
            Collection.FindOne(Query.EQ("_id", id));

        public Block GetByHash(string hash) =>
            Collection.FindOne(b => b.Hash == hash);
    }
}
