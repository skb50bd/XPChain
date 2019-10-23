using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Persistence
{
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Insert a new document into collection. Document Id must be a new value in collection - Returns document Id
        /// </summary>
        void Insert<T>(
            T       entity,
            string? collectionName = null);

        /// <summary>
        /// Insert an array of new documents into collection. Document Id must be a new value in collection. Can be set buffer size to commit at each N documents
        /// </summary>
        int Insert<T>(
            IEnumerable<T> entities,
            string?        collectionName = null);

        /// <summary>
        /// Returns all the documents from the collection.
        /// </summary>
        List<T> GetAll<T>();

        /// <summary>
        /// Search for a single instance of T by Id. Shortcut from Query.SingleById
        /// </summary>
        T SingleById<T>(Guid id, string? collectionName = null);

        /// <summary>
        /// Execute Query[T].Where(predicate).ToList();
        /// </summary>
        List<T> Fetch<T>(
            Expression<Func<T, bool>> predicate,
            string?                   collectionName = null);

        /// <summary>
        /// Execute Query[T].Where(predicate).First();
        /// </summary>
        T First<T>(
            Expression<Func<T, bool>> predicate,
            string?                   collectionName = null);

        /// <summary>
        /// Execute Query[T].Where(predicate).FirstOrDefault();
        /// </summary>
        T FirstOrDefault<T>(
            Expression<Func<T, bool>> predicate,
            string?                   collectionName = null);

        /// <summary>
        /// Execute Query[T].Where(predicate).Single();
        /// </summary>
        T Single<T>(
            Expression<Func<T, bool>> predicate,
            string?                   collectionName = null);

        /// <summary>
        /// Execute Query[T].Where(predicate).SingleOrDefault();
        /// </summary>
        T SingleOrDefault<T>(
            Expression<Func<T, bool>> predicate,
            string?                   collectionName = null);
    }
}
