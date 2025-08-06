using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Unit
{
    public class CreateUnitDto
    {
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
