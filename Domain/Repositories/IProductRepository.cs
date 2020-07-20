using System.Collections.Generic;
using System.Threading.Tasks;
using testef.Domain.Dtos;
using testef.Entities.Models;

namespace testef.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);
        Task<List<Product>> ListAllAsync();
        Task<List<Product>> ListAllByCategoryAsync(int categoryId);
        Task<Product> SaveAsync(ProductDto model);
    }
}