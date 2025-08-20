using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Product
{
    public class CreateProductDto
    {
        [Required, MaxLength(80)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Range(0, 9999999999999999.99)]
        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int StockNow { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        [Required]
        public int ProductUnitId { get; set; }

        [Required, MaxLength(80)]
        public required string Supplier { get; set; }

        [MaxLength(30)]
        public string? Color { get; set; }
    }
}
