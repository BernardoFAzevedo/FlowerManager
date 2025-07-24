using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class AppUser : IdentityUser
    {

        [Required]
        [Phone]
        [StringLength(9, MinimumLength = 9)]
        public override string PhoneNumber { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "")]
        public string PIN { get; set; }
    }
}