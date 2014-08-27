using AutoMapper;

using Korann.DAL.DTO;
using Korann.Infrastructure.Models;

namespace Korann.Configuration
{
    public class DTOConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Product, ProductModel>();
            Mapper.CreateMap<ProductModel, Product>();

            Mapper.CreateMap<Category, CategoryModel>();
            Mapper.CreateMap<CategoryModel, Category>();
        }
    }
}