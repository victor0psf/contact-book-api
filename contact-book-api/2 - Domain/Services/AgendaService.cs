#nullable enable
using contact_book_api.Interfaces.IService;
using contact_book_api.IRepository;
using contact_book_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

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
        if (string.IsNullOrEmpty(agenda.Title))
        {
            return null;//tratar mensagem de erro
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
            
            if (agendaExistente == null) 
                return null;
            
            _agendaRepository.Update(agenda);
            
            return  agendaExistente;

    }

    public async Task<AgendaModel?> Delete(Guid id)
    {

        var agendaExistente = _agendaRepository.Get(id);
        
        if(agendaExistente == null)
            return null;
        
        await  _agendaRepository.Delete(id);

        return null;
    }

    public Task<List<AgendaModel>> GetAll()
    {
        var registros =  _agendaRepository.GetAll();
        
        if(registros == null) 
            return null;
        
        return registros;
    }

    public Task<AgendaModel> GetById(Guid id)
    {
        if (id == Guid.Empty) 
            return null;
        
        var agenda = _agendaRepository.Get(id);
        
        return agenda;
    }
}