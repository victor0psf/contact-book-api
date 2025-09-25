using contact_book_api._1___Presentation.Dto;
using contact_book_api._1___Presentation.Mapping;
using contact_book_api._2___Domain.Services;
using contact_book_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace contact_book_api.Controllers;

public class AgendaController(AgendaService agendaService, AgendaMap agendaMap) : ControllerBase
{
    private readonly AgendaService _agendaService = agendaService;
    private readonly AgendaMap _agendaMap = agendaMap;

    [HttpPost("AddAgenda")]
    public async Task<IActionResult> AddAgenda(AgendaDto agendaDto)
    {
        var entitieMaped = _agendaMap.AgendaDtoForAgendaDomain(agendaDto);
        
         await _agendaService.Add(entitieMaped);
         
         return Created("Agenda criada", entitieMaped);
    }

    [HttpPut("UpdateAgenda")]
    public async Task<IActionResult> UpdateAgenda(AgendaDto agendaDto, Guid id)
    {
        try
        {
            var entitieMaped = _agendaMap.AgendaDtoForAgendaDomain(agendaDto);

            var entidadeAtualizada = await _agendaService.Update(entitieMaped, id);
            
            return Ok(entidadeAtualizada);
        }
        catch (Exception ex)
        {
            
            return StatusCode(500, "Erro ao atualizar dados da agenda");
            
        }
    }
    
    
}