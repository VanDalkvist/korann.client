using System.Web.Http;

using Korann.Infrastructure.Contracts;

namespace Korann.Controllers.API
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // /api/products/
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        // /api/products?id={id}
        [HttpGet]
        public IHttpActionResult GetEntity(string id)
        {
            return Ok(_productService.GetEntity(id));
        }

        // /api/products?category={category}
        [HttpGet]
        public IHttpActionResult GetByCategory(string category)
        {
            return Ok(_productService.GetByCategory(category));
        }
    }
}