using contact_book_api.Models;

namespace contact_book_api.Interfaces.IService;

public interface IAgendaService
{
    Task<AgendaModel> Add(AgendaModel agenda);
    
    Task<AgendaModel> Update(AgendaModel agenda, Guid id);
    
    Task<AgendaModel> Delete(Guid id);
    
    Task<List<AgendaModel>> GetAll();
    
    Task<AgendaModel> Get(Guid id);
}