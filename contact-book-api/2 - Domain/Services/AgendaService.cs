#nullable enable
using contact_book_api.Interfaces.IService;
using contact_book_api.IRepository;
using contact_book_api.Models;

namespace contact_book_api._2___Domain.Services;

public class AgendaService : IAgendaService
{
    private readonly IAgendaRepository _agendaRepository;

    public AgendaService(IAgendaRepository agendaRepository)
    {
        _agendaRepository = agendaRepository;
    }
    
    public async Task<AgendaModel> Add(AgendaModel agenda)
    {
        if (string.IsNullOrEmpty(agenda.Title) || agenda.Contacts.Count == 0)
        {
            return null;
        }
            
        await _agendaRepository.Add(agenda);
        return agenda;

    }

    public Task<AgendaModel?> Update(AgendaModel agenda)
    {
        throw new NotImplementedException();
    }

    public Task<AgendaModel>? Update(AgendaModel agenda, Guid id)
    {
            var agendaExistente = _agendaRepository.Get(id);
            if (agendaExistente == null) return null;
            
            _agendaRepository.Update(agenda);
            
            return  agendaExistente;

    }

    public Task<AgendaModel> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AgendaModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<AgendaModel> Get(Guid id)
    {
        throw new NotImplementedException();
    }
}