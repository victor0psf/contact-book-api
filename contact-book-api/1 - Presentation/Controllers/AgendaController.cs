using contact_book_api._1___Presentation.Dto;
using contact_book_api._1___Presentation.Mapping;
using contact_book_api._2___Domain.Services;
using contact_book_api.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace contact_book_api._1___Presentation.Controllers;

public class AgendaController(IAgendaService agendaService, AgendaMap agendaMap) : ControllerBase
{
    private readonly IAgendaService _agendaService = agendaService;

    [HttpPost("AddAgenda")]
    public async Task<IActionResult> AddAgenda([FromBody] AgendaDto agendaDto)
    {
        var entitieMaped = agendaMap.AgendaDtoForAgendaDomain(agendaDto);
        
         await _agendaService.Add(entitieMaped);
         
         return Created("Agenda criada", entitieMaped);
    }

    [HttpPut("UpdateAgenda")]
    public async Task<IActionResult> UpdateAgenda(AgendaDto agendaDto, Guid id)
    {
        try
        {
            var entitieMaped = agendaMap.AgendaDtoForAgendaDomain(agendaDto);

            var entidadeAtualizada = await _agendaService.Update(entitieMaped, id);
            
            return Ok(entidadeAtualizada);
        }
        catch (Exception ex)
        {
            
            return StatusCode(500, "Erro ao atualizar dados da agenda");
            
        }
    }

    [HttpDelete("DeleteAgenda")]
    public async Task<IActionResult> DeleteAgenda(Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound();
        }
        await _agendaService.Delete(id);
        return NoContent();

    }

    #region MyRegion

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var agenda = await _agendaService.GetById(id);
            return Ok(agenda);
        }
        catch
        {
            return StatusCode(404, "Erro ao listar registro selecionado");
        }
    }

    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var agendas = await _agendaService.GetAll();
            return Ok(agendas);
        }
        catch
        {
            return StatusCode(404, "Erro ao listar registros.");
        }
    }
    
    
    #endregion
    
    
}