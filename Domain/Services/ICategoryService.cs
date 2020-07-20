using System.Collections.Generic;
using System.Threading.Tasks;
using testef.Domain.Dtos;

namespace testef.Domain.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> ListAllAsync();
        Task<CategoryDto> SaveCategoryAsync(CategoryDto model);
    }
}