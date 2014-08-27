using System.Collections.Generic;

using AutoMapper;

using Korann.DAL.Contracts;
using Korann.Infrastructure.Contracts;
using Korann.Infrastructure.Models;
using Korann.Utils;

namespace Korann.Infrastructure.Services
{
    public abstract class EntityService<TEntity, TEntityModel> : IEntityService<TEntityModel>
        where TEntityModel : class, IEntityModel, new()
        where TEntity : class, IEntity, new()
    {
        protected readonly IRepository<TEntity> EntityRepository;

        protected EntityService(IRepository<TEntity> entityRepository)
        {
            EntityRepository = entityRepository;
        }

        public TEntityModel GetEntity(string id)
        {
            var entity = EntityRepository.GetOne(id);
            return Mapper.Map<TEntityModel>(entity);
        }

        public IEnumerable<TEntityModel> GetAll()
        {
            var entities = EntityRepository.GetAll();
            return entities.SelectOrDefault(Mapper.Map<TEntityModel>);
        }
    }
}