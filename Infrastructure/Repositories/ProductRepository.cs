using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testef.Domain.Dtos;
using testef.Domain.Repositories;
using testef.Entities.Models;
using testef.Infrastructure.Data;
using testef.Infrastructure.Repositories;

namespace Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

        public async Task<Product> GetAsync(int id)
        {
            return await Context.Products
                .Where(p => p.Id == id)
                .Include(c => c.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> ListAllAsync()
        {
            return await Context.Products
                .Include(c => c.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Product>> ListAllByCategoryAsync(int categoryId)
        {
            return await Context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(c => c.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> SaveAsync(ProductDto model)
        {
            var product = await GetAsync(model.Id);
            if (product == null)
            {
                product = new Product();
            }

            product.CategoryId = model.Category.Id;
            product.Description = model.Description;
            product.Price = model.Price;

            await Context.Products.AddAsync(product);
            product.Id = await Context.SaveChangesAsync();

            return await GetAsync(product.Id);
        }
    }
}