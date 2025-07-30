using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Category;

public class UpdateCategoryDto
    {
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
    }