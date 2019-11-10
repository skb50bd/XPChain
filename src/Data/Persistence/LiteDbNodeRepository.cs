using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LiteDB;
using Microsoft.Extensions.Options;

namespace Data.Persistence
{
    public class LiteDbNodeRepository: INodeRepository
    {
        #region Properties

        /// <summary>
        /// Get database instance
        /// </summary>
        private LiteRepository Repository { get; }

        #endregion

        #region Ctor

        public LiteDbNodeRepository(
            IOptionsMonitor<LiteSettings> settings,
            BsonMapper                    mapper = null)
        {
            if (mapper is null) mapper = BsonMapper.Global;
            Repository = new LiteRepository(settings.CurrentValue.Node, mapper);
        }

        #endregion


        #region Insert

        /// <summary>
        /// Insert a new document into collection. Document Id must be a new value in collection - Returns document Id
        /// </summary>
        public void Insert<T>(
            T      entity,
            string collectionName = null) =>
            Repository.Insert<T>(entity, collectionName);

        /// <summary>
        /// Insert an array of new documents into collection. Document Id must be a new value in collection. Can be set buffer size to commit at each N documents
        /// </summary>
        public int Insert<T>(
            IEnumerable<T> entities,
            string         collectionName = null) =>
            Repository.Insert<T>(entities, collectionName);

        #endregion

        #region Shortcuts

        public List<T> GetAll<T>()
            => Repository.Query<T>().ToList();

        /// <summary>
        /// Search for a single instance of T by Id. Shortcut from Query.SingleById
        /// </summary>
        public T SingleById<T>(ObjectId id, string collectionName = null) =>
            Repository.SingleById<T>(new BsonValue(id), collectionName);

        /// <summary>
        /// Execute Query[T].Where(predicate).ToList();
        /// </summary>
        public List<T> Fetch<T>(
            Expression<Func<T, bool>> predicate,
            string                    collectionName = null)
            => Repository.Fetch<T>(predicate, collectionName);

        /// <summary>
        /// Execute Query[T].Where(predicate).First();
        /// </summary>
        public T First<T>(
            Expression<Func<T, bool>> predicate,
            string                    collectionName = null)
            => Repository.First<T>(predicate, collectionName);

        /// <summary>
        /// Execute Query[T].Where(predicate).FirstOrDefault();
        /// </summary>
        public T FirstOrDefault<T>(
            Expression<Func<T, bool>> predicate,
            string                    collectionName = null)
            => Repository.FirstOrDefault<T>(predicate, collectionName);

        /// <summary>
        /// Execute Query[T].Where(predicate).Single();
        /// </summary>
        public T Single<T>(
            Expression<Func<T, bool>> predicate,
            string                    collectionName = null)
            => Repository.Single<T>(predicate, collectionName);

        /// <summary>
        /// Execute Query[T].Where(predicate).SingleOrDefault();
        /// </summary>
        public T SingleOrDefault<T>(
            Expression<Func<T, bool>> predicate,
            string                    collectionName = null)
            => Repository.SingleOrDefault<T>(predicate, collectionName);

        public bool Update<T>(T item, string collectionName = null) =>
            Repository.Update(item, collectionName);

        public bool Delete<T>(ObjectId id, string collectionName = null) =>
            Repository.Delete<T>(new BsonValue(id), collectionName);

        public bool Delete<T>(T item, string collectionName = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool cleanAll)
        {
            Repository.Dispose();

        }
    }
}
