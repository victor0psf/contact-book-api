using contact_book_api._1___Presentation.Dto;
using contact_book_api.Models;

namespace contact_book_api._1___Presentation.Mapping;

public class AgendaMap
{
    public AgendaMap(){}

    public AgendaModel AgendaDtoForAgendaDomain(AgendaDto agendaDto)
    {
        return new AgendaModel
        {
            Title = agendaDto.Title?.Trim() ?? string.Empty
        };
    }
    
    
}