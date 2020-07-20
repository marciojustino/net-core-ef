using System.Collections.Generic;
using System.Threading.Tasks;
using testef.Domain.Dtos;
using testef.Domain.Repositories;
using testef.Entities.Models;

namespace testef.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> ListAllAsync()
        {
            var categories = await _categoryRepository.ListAllAsync();
            return Category.Dto(categories);
        }

        public async Task<CategoryDto> SaveCategoryAsync(CategoryDto model)
        {
            var category = await _categoryRepository.SaveAsync(model);
            return Category.Dto(category);
        }
    }
}