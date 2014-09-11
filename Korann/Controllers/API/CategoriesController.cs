using System.Web.Http;

using Korann.Infrastructure.Contracts;

namespace Korann.Controllers.API
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET /api/categories
        [Route]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        // GET /api/categories/{id}
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(_categoryService.GetEntity(id));
        }
    }
}