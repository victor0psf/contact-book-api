using contact_book_api._1___Presentation.Dto;
using contact_book_api.Models;

namespace contact_book_api._1___Presentation.Mapping;

public class ContactMap
{
    public ContactMap() { }
    public ContactModel ToModel(ContactDto dto)
    {
        return new ContactModel
        {
            Name = dto.Name,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            CreatedAt = dto.CreatedAt
        };
    }

}
