using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using Korann.DAL.Contracts;
using Korann.DAL.DTO;
using Korann.Infrastructure.Contracts;
using Korann.Infrastructure.Models;

namespace Korann.Infrastructure.Services
{
    public class ProductService : EntityService<Product, ProductModel>, IProductService
    {
        public ProductService(IProductRepository entityRepository)
            : base(entityRepository)
        {
        }

        public IEnumerable<ProductModel> GetByCategory(string category)
        {
            return EntityRepository
                .GetManyBy(product => product.Category, category)
                .Select(Mapper.Map<ProductModel>);
        }
    }
}