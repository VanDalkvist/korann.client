using Korann.DAL.Contracts;
using Korann.DAL.DTO;
using Korann.Infrastructure.Contracts;
using Korann.Infrastructure.Models;

namespace Korann.Infrastructure.Services
{
    public class CategoryService : EntityService<Category, CategoryModel>, ICategoryService
    {
        public CategoryService(ICategoryRepository entityRepository)
            : base(entityRepository)
        {
        }
    }
}