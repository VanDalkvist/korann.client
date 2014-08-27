using Korann.DAL.Contracts;
using Korann.DAL.DTO;

namespace Korann.DAL.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        protected override string CollectionName
        {
            get { return "categories"; }
        }
    }
}