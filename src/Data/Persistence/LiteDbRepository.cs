using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain;
using Newtonsoft.Json;

namespace Data.Persistence
{
    public class LiteDbRepository : IRepository
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

        public LiteDbRepository(
            IOptionsMonitor<LiteSettings> settings,
            BsonMapper mapper = null)
        {
            if(mapper is null) mapper = BsonMapper.Global;
            Db = new LiteDatabase(settings.CurrentValue.ConnectionString, mapper);
            Collection.EnsureIndex(b => b.Hash);
            Collection.EnsureIndex(b => b.PreviousBlockHash);
        }

        public LiteDbRepository(
            string connectionString)
        {
            Db = new LiteDatabase( connectionString);
        }

        #endregion


        //#region Insert

        ///// <summary>
        ///// Insert a new document into collection. Document Id must be a new value in collection - Returns document Id
        ///// </summary>
        //public void Insert<T>(
        //    T entity,
        //    string collectionName = null) =>
        //    Repository.Insert<T>(entity, collectionName);

        ///// <summary>
        ///// Insert an array of new documents into collection. Document Id must be a new value in collection. Can be set buffer size to commit at each N documents
        ///// </summary>
        //public int Insert<T>(
        //    IEnumerable<T> entities,
        //    string collectionName = null) =>
        //    Repository.Insert<T>(entities, collectionName);

        //#endregion

        //#region Shortcuts


        //public List<T> GetAll<T>() 
        //    => Repository.Query<T>().ToList();

        ///// <summary>
        ///// Search for a single instance of T by Id. Shortcut from Query.SingleById
        ///// </summary>
        //public T SingleById<T>(Guid id, string collectionName = null) =>
        //    Repository.SingleById<T>(new BsonValue(id), collectionName);

        ///// <summary>
        ///// Execute Query[T].Where(predicate).ToList();
        ///// </summary>
        //public List<T> Fetch<T>(
        //    Expression<Func<T, bool>> predicate,
        //    string collectionName = null) 
        //    => Repository.Fetch<T>(predicate, collectionName);

        ///// <summary>
        ///// Execute Query[T].Where(predicate).First();
        ///// </summary>
        //public T First<T>(
        //    Expression<Func<T, bool>> predicate,
        //    string collectionName = null) 
        //    => Repository.First<T>(predicate, collectionName);

        ///// <summary>
        ///// Execute Query[T].Where(predicate).FirstOrDefault();
        ///// </summary>
        //public T FirstOrDefault<T>(
        //    Expression<Func<T, bool>> predicate,
        //    string collectionName = null) 
        //    => Repository.FirstOrDefault<T>(predicate, collectionName);

        ///// <summary>
        ///// Execute Query[T].Where(predicate).Single();
        ///// </summary>
        //public T Single<T>(
        //    Expression<Func<T, bool>> predicate,
        //    string collectionName = null)
        //    => Repository.Single<T>(predicate, collectionName);

        ///// <summary>
        ///// Execute Query[T].Where(predicate).SingleOrDefault();
        ///// </summary>
        //public T SingleOrDefault<T>(
        //    Expression<Func<T, bool>> predicate,
        //    string collectionName = null) 
        //    => Repository.SingleOrDefault<T>(predicate, collectionName);

        //#endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool cleanAll)
        {
            Db.Dispose();

        }

        public string GetLastBlockHash() => GetLastBlock()?.Hash;

        public Block GetLastBlock() =>
            Collection.FindOne(Query.All(Query.Descending));

        public Block Insert(Block item)
        {
            if (item.Hash is null) item.SetHash();
            if (item.Signature is null) throw new Exception("Block is not signed.");

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

        public T GetById<T>(Guid id)
        {
            return JsonConvert.DeserializeObject<T>(
                Collection.FindOne(
                    b => b.Type == typeof(T).Name
                         && b.Data.Contains(id.ToString()))
                          .Data);
        }

        public Block GetById(ObjectId id) =>
            Collection.FindOne(Query.EQ("_id", id));

        public Block GetByHash(string hash) =>
            Collection.FindOne(b => b.Hash == hash);
    }
}
