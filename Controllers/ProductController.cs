using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testef.Data;
using testef.Models;

namespace testef.Controllers
{
    /// <summary>
    /// Product services
    /// </summary>
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// List all existent products
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            return await context.Products
                .Include(c => c.Category)
                .ToListAsync();
        }

        /// <summary>
        /// Get product by product identification
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id">Product identification</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, [FromRoute] int id)
        {
            return await context.Products
                .Include(c => c.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// List all products from category
        /// </summary>
        /// <param name="context"></param>
        /// <param name="categoryId">Category identification</param>
        /// <returns></returns>
        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context, [FromRoute] int categoryId)
        {
            return await context.Products
                .Include(c => c.Category)
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        /// <summary>
        /// Save product data
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model">Product data</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromServices] DataContext context, [FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
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