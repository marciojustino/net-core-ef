using System.Collections.Generic;
using System.Threading.Tasks;
using testef.Domain.Dtos;
using testef.Entities.Models;

namespace testef.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(int id);
        Task<List<Category>> ListAllAsync();
        Task<Category> SaveAsync(CategoryDto model);
    }
}