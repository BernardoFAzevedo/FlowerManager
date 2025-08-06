using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ProductUnit
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
