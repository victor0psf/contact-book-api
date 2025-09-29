using contact_book_api._1___Presentation.Dto;
using contact_book_api._1___Presentation.Mapping;
using contact_book_api.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace contact_book_api._1___Presentation.Controllers;

public class AgendaController(IAgendaService agendaService, AgendaMap agendaMap, ILogger<AgendaController> logger) : ControllerBase
{
    private readonly IAgendaService _agendaService = agendaService;
    private readonly ILogger<AgendaController> _logger = logger;

    [HttpPost("AddAgenda")]
    public async Task<IActionResult> AddAgenda([FromBody] AgendaDto agendaDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var entitieMaped = agendaMap.AgendaDtoForAgendaDomain(agendaDto);

            await _agendaService.Add(entitieMaped);

            return Created("Agenda criada", entitieMaped);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar agenda");
            return StatusCode(500, "Erro ao criar agenda");
        }
    }

    [HttpPut("UpdateAgenda")]
    public async Task<IActionResult> UpdateAgenda(AgendaDto agendaDto, Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var entitieMaped = agendaMap.AgendaDtoForAgendaDomain(agendaDto);

            var entidadeAtualizada = await _agendaService.Update(entitieMaped, id);

            return Ok(entidadeAtualizada);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar dados da agenda");
            return StatusCode(500, "Erro ao atualizar dados da agenda");

        }
    }

    [HttpDelete("DeleteAgenda")]
    public async Task<IActionResult> DeleteAgenda(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            await _agendaService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar agenda");
            return StatusCode(500, "Erro ao deletar agenda");
        }

    }

    #region MyRegion

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var agenda = await _agendaService.GetById(id);
            return Ok(agenda);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar registro selecionado");
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar registros.");
            return StatusCode(404, "Erro ao listar registros.");
        }
    }
    #endregion
}