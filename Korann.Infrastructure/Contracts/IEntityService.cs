using System.Collections.Generic;

using Korann.Infrastructure.Models;

namespace Korann.Infrastructure.Contracts
{
    public interface IEntityService<out TEntityModel>
        where TEntityModel : class, IEntityModel, new()
    {
        TEntityModel GetEntity(string id);

        IEnumerable<TEntityModel> GetAll();
    }
}