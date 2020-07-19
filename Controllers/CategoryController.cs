using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testef.Data;
using testef.Models;

namespace testef.Controllers
{
    /// <summary>
    /// Category services
    /// </summary>
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        /// <summary>
        /// List all existent categories
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            return await context.Categories.ToListAsync();
        }

        /// <summary>
        /// Save category data
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model">Category data</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}