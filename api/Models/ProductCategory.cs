using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
