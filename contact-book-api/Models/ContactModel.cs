using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace contact_book_api.Models
{
    public class ContactModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(120)]
        public string Name { get; set; } = null!;

        [Required, MaxLength(15)]
        public string PhoneNumber { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}