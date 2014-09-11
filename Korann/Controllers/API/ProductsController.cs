using System.Web.Http;

using Korann.Infrastructure.Contracts;

namespace Korann.Controllers.API
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET /api/products/
        [Route]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        // GET /api/products/{id}
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(_productService.GetEntity(id));
        }

        // GET /api/products/filter?category={category}
        [Route("filter")]
        [HttpGet]
        public IHttpActionResult GetFiltered([FromUri] string category)
        {
            return Ok(_productService.GetByCategory(category));
        }
    }
}