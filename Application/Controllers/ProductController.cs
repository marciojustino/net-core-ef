using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testef.Domain.Dtos;
using testef.Domain.Services;

namespace testef.Controllers
{
    /// <summary>
    /// Product services
    /// </summary>
    [ApiController]
    [Route("v1/products")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// List all existent products
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            return await _productService.ListAllProducts();
            // return await context.Products
            //     .Include(c => c.Category)
            //     .ToListAsync();
        }

        /// <summary>
        /// Get product by product identification
        /// </summary>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute] int id)
        {
            return await _productService.GetProduct(id);
            // return await context.Products
            //     .Include(c => c.Category)
            //     .AsNoTracking()
            //     .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// List all products from category
        /// </summary>
        [HttpGet]
        [Route("categories/{categoryId:int}")]
        public async Task<ActionResult<List<ProductDto>>> GetByCategory([FromRoute] int categoryId)
        {
            return await _productService.ListAllProductsByCategory(categoryId);
            // return await context.Products
            //     .Include(c => c.Category)
            //     .AsNoTracking()
            //     .Where(p => p.CategoryId == categoryId)
            //     .ToListAsync();
        }

        /// <summary>
        /// Save product data
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ProductDto>> Post([FromBody] ProductDto model)
        {
            if (ModelState.IsValid)
            {
                return await _productService.SaveProduct(model);
                // context.Products.Add(model);
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