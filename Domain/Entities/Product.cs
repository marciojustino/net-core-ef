using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using testef.Domain.Dtos;

namespace testef.Entities.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        [MaxLength(60, ErrorMessage = "O título deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "O título deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "A descrição deve conter no máximo 1024 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        internal static ProductDto Dto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Category = new CategoryDto
                {
                    Id = product.Category.Id,
                    Title = product.Category.Title
                },
                Description = product.Description,
                Price = product.Price,
                Title = product.Title
            };
        }

        internal static List<ProductDto> Dto(List<Product> products)
        {
            if (products == null)
            {
                return null;
            }

            var listDto = new List<ProductDto>();
            foreach (var prod in products)
            {
                listDto.Add(Dto(prod));
            }

            return listDto;
        }
    }
}