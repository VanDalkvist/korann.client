using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Korann.DAL.Contracts;
using Korann.DAL.Management;

using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Korann.DAL.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected MongoCollection<TEntity> Collection;

        protected RepositoryBase()
        {
            InitializeCollection();
        }

        private void InitializeCollection()
        {
            Collection = DBManager.Database.GetCollection<TEntity>(CollectionName);
        }

        protected abstract string CollectionName { get; }

        public IEnumerable<TEntity> GetAll()
        {
            return Collection.FindAll();
        }

        public IEnumerable<TEntity> GetManyBy(params string[] ids)
        {
            var builder = new QueryBuilder<TEntity>();
            var query = builder.In(product => product.Id, ids);
            return Collection.Find(query);
        }

        public IEnumerable<TEntity> GetManyBy<TResult>(Expression<Func<TEntity, TResult>> memberExpression, TResult value)
        {
            var query = Query<TEntity>.EQ(memberExpression, value);
            return Collection.Find(query);
        }

        public IEnumerable<TEntity> GetManyBy<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> memberExpression, TResult value)
        {
            var query = Query<TEntity>.EQ(memberExpression, value);
            return Collection.Find(query);
        }

        public TEntity GetOne(string id)
        {
            return GetOne(p => p.Id, id);
        }

        public TEntity GetOne<TResult>(Expression<Func<TEntity, TResult>> memberExpression, TResult value)
        {
            var query = Query<TEntity>.EQ(memberExpression, value);
            return Collection.FindOne(query);
        }

        public string Create(TEntity entity)
        {
            var result = Collection.Save(entity);
            return result.Ok ? BsonSerializer.Deserialize<TEntity>(result.Response).Id : string.Empty;
        }

        public void Update(TEntity entity)
        {
            var updateQuery = Update<TEntity>.Replace(entity);
            Collection.Update(GetByIdQuery(entity.Id), updateQuery);
        }

        public void Delete(string id)
        {
            Collection.Remove(GetByIdQuery(id));
        }

        private IMongoQuery GetByIdQuery(string id)
        {
            return Query<TEntity>.EQ(p => p.Id, id);
        }
    }
}