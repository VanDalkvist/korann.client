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
        protected readonly IApiClient _apiClient;

        protected virtual string Resource { get; private set; }

        protected EntityService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public TEntityModel GetEntity(string id)
        {
            var response = _apiClient.Get<TEntity>(Resource + "/" + id);
            return Mapper.Map<TEntityModel>(response);
        }

        public IEnumerable<TEntityModel> GetAll()
        {
            var entities = _apiClient.Get<List<TEntity>>(Resource);
            return entities.SelectOrDefault(Mapper.Map<TEntityModel>);
        }
    }
}