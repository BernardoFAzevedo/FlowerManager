using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 9999999999999999.99)]
        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int StockNow { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }

        [Required]
        public int ProductUnitId { get; set; }
        public ProductUnit? ProductUnit { get; set; }

        [Required, MaxLength(80)]
        public required string Supplier { get; set; }

        public bool IsActive { get; set; } = true;
    }

    //TODO: Adicionar foto, cor, 

}
