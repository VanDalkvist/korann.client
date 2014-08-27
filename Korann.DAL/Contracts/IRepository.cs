using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Korann.DAL.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetManyBy(params string[] ids);

        IEnumerable<TEntity> GetManyBy<TResult>(Expression<Func<TEntity, TResult>> memberExpression, TResult value);

        IEnumerable<TEntity> GetManyBy<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> memberExpression, TResult value);

        TEntity GetOne(string id);

        TEntity GetOne<TResult>(Expression<Func<TEntity, TResult>> memberExpression, TResult value);

        string Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(string id);
    }
}