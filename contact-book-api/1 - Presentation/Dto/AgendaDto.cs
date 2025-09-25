using contact_book_api.Models;

namespace contact_book_api._1___Presentation.Dto;

public class AgendaDto
{
    public string Title { get; set; }
    public List<ContactModel> Contacts { get; set; } = new List<ContactModel>();
    
}