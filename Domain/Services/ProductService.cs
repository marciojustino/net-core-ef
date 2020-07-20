using System.Collections.Generic;
using System.Threading.Tasks;
using testef.Domain.Dtos;
using testef.Domain.Repositories;
using testef.Entities.Models;

namespace testef.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await _productRepository.GetAsync(id);
            return Product.Dto(product);
        }

        public async Task<List<ProductDto>> ListAllProducts()
        {
            var products = await _productRepository.ListAllAsync();
            return Product.Dto(products);
        }

        public async Task<List<ProductDto>> ListAllProductsByCategory(int categoryId)
        {
            var products = await _productRepository.ListAllByCategoryAsync(categoryId);
            return Product.Dto(products);
        }

        public async Task<ProductDto> SaveProduct(ProductDto model)
        {
            var product = await _productRepository.SaveAsync(model);
            return Product.Dto(product);
        }
    }
}