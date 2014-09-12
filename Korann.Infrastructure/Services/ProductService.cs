using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using Korann.DAL.Contracts;
using Korann.DAL.DTO;
using Korann.Infrastructure.Contracts;
using Korann.Infrastructure.Models;

using RestSharp;

namespace Korann.Infrastructure.Services
{
    public class ProductService : EntityService<Product, ProductModel>, IProductService
    {
        public ProductService(IApiClient apiClient) : base(apiClient) { }

        public IEnumerable<ProductModel> GetByCategory(string category)
        {
//            return EntityRepository
//                .GetManyBy(product => product.Category, category)
//                .Select(Mapper.Map<ProductModel>);
            throw new NotImplementedException();
        }
    }
}