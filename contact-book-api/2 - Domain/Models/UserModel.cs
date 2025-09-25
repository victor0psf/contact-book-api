using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace contact_book_api.Models
{
    public class UserModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(120)]
        public string Username { get; set; } = null!;

        [Required, MaxLength(160), EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}