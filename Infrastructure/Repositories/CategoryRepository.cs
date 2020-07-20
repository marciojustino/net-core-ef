using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testef.Domain.Dtos;
using testef.Domain.Repositories;
using testef.Entities.Models;
using testef.Infrastructure.Data;

namespace testef.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Category>> ListAllAsync()
        {
            return await Context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> SaveAsync(CategoryDto model)
        {
            Category category = await GetAsync(model.Id);

            if (category == null)
            {
                category = new Category();
            }

            category.Title = model.Title;
            await Context.Categories.AddAsync(category);
            await Context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> GetAsync(int id)
        {
            return await Context.Categories
                .Where(c => c.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}