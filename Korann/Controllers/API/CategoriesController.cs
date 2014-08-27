using System.Web.Http;

using Korann.Infrastructure.Contracts;

namespace Korann.Controllers.API
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // /api/categories
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        // /api/categories?id={id}
        [HttpGet]
        public IHttpActionResult GetEntity(string id)
        {
            return Ok(_categoryService.GetEntity(id));
        }
    }
}