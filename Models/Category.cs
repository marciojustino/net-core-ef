using System.ComponentModel.DataAnnotations;

namespace testef.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Título da categoria é obrigatório")]
        [MaxLength(60, ErrorMessage="O título deve ter conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage="O título deve ter conter entre 3 e 60 caracteres")]
        public string Title { get; set; }
    }
}