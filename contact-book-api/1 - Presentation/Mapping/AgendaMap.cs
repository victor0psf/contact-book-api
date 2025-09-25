using contact_book_api._1___Presentation.Dto;
using contact_book_api.Models;

namespace contact_book_api._1___Presentation.Mapping;

public class AgendaMap
{
    public AgendaMap(){}

    public AgendaModel AgendaDtoForAgendaDomain(AgendaDto agendaDto)
    {
        var obj = new AgendaModel()
        {
            Title = agendaDto.Title,
            Contacts = agendaDto.Contacts,
        };
        return obj;
    }
    
    
}