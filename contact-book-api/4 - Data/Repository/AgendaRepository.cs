using contact_book_api.Data;
using contact_book_api.IRepository;
using contact_book_api.Models;
using Microsoft.EntityFrameworkCore;

namespace contact_book_api.Repository;

public class AgendaRepository(AppDbContext context) : IAgendaRepository
{

    private readonly AppDbContext _context = context;

    public async Task<AgendaModel> Add(AgendaModel agenda)
    {
        await _context.Agendas.AddAsync(agenda);
        await _context.SaveChangesAsync();
        return agenda;
    }

    public async Task<AgendaModel> Update(AgendaModel agenda)
    { 
        _context.Agendas.Update(agenda);
        await _context.SaveChangesAsync();
        return agenda;
    }

    public async Task<AgendaModel> Delete(Guid id)
    {
        var registroEncontrado = await _context.Agendas.FindAsync(id);
         _context.Agendas.Remove(registroEncontrado);
        await _context.SaveChangesAsync();
        return await Task.FromResult(registroEncontrado);
    }

    public async Task<List<AgendaModel>> GetAll()
    {
        return await _context.Agendas.ToListAsync();
    }

    public async Task<AgendaModel> Get(Guid id)
    {
        return await _context.Agendas.FirstOrDefaultAsync(x => x.Id == id);
    }
}