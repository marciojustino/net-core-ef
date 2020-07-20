using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using testef.Domain.Dtos;

namespace testef.Entities.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Título da categoria é obrigatório")]
        [MaxLength(60, ErrorMessage = "O título deve ter conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "O título deve ter conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

        internal static CategoryDto Dto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Title = category.Title
            };
        }

        internal static List<CategoryDto> Dto(List<Category> categories)
        {
            if (categories == null)
            {
                return null;
            }

            var listDto = new List<CategoryDto>();
            foreach (var cat in categories)
            {
                listDto.Add(Dto(cat));
            }

            return listDto;
        }
    }
}