using System.Collections.Generic;

using Korann.Infrastructure.Models;

namespace Korann.Infrastructure.Contracts
{
    public interface IProductService : IEntityService<ProductModel>
    {
        IEnumerable<ProductModel> GetByCategory(string category);
    }
}