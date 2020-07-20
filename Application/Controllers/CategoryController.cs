using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testef.Domain.Dtos;
using testef.Domain.Services;

namespace testef.Controllers
{
    /// <summary>
    /// Category services
    /// </summary>
    [ApiController]
    [Route("v1/categories")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// List all existent categories
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            return await _categoryService.ListAllAsync();
            // return await context.Categories.ToListAsync();
        }

        /// <summary>
        /// Save category data
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryDto model)
        {
            if (ModelState.IsValid)
            {
                return await _categoryService.SaveCategoryAsync(model);
                // context.Categories.Add(model);
                // await context.SaveChangesAsync();
                // return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}