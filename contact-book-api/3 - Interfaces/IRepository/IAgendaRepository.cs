using contact_book_api.Models;

namespace contact_book_api.IRepository;

public interface IAgendaRepository
{
    Task<AgendaModel> Add(AgendaModel agenda);

    Task<AgendaModel> Update(AgendaModel agenda);

    Task<AgendaModel> Delete(Guid id);

    Task<List<AgendaModel>> GetAll();

    Task<AgendaModel> Get(Guid id);
}