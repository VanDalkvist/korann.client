using Korann.DAL.Contracts;
using Korann.DAL.DTO;

namespace Korann.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        protected override string CollectionName
        {
            get { return "products"; }
        }
    }
}