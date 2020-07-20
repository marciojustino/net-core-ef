using System.Collections.Generic;
using System.Threading.Tasks;
using testef.Domain.Dtos;

namespace testef.Domain.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> ListAllProducts();
        Task<ProductDto> GetProduct(int id);
        Task<List<ProductDto>> ListAllProductsByCategory(int categoryId);
        Task<ProductDto> SaveProduct(ProductDto model);
    }
}