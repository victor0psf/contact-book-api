using contact_book_api.Models;

namespace contact_book_api._1___Presentation.Dto;

public class ContactDto
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
