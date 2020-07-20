namespace testef.Domain.Dtos
{
    public class ProductDto : EntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryDto Category { get; set; }
    }
}