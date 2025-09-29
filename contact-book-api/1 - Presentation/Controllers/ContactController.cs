using contact_book_api._1___Presentation.Dto;
using contact_book_api._1___Presentation.Mapping;
using contact_book_api._2___Domain.Services;
using contact_book_api.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace contact_book_api._1___Presentation.Controllers;

public class ContactController(IContactService contactService, ContactMap contactMap, ILogger<ContactController> logger) : ControllerBase
{
    private readonly IContactService _contactService = contactService;
    private readonly ILogger<ContactController> _logger = logger;

    [HttpPost("AddContact")]
    public async Task<IActionResult> AddContact([FromBody] ContactDto contactDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {

            var entitieMaped = contactMap.ToModel(contactDto);
            await _contactService.Add(entitieMaped);

            return Created("Contato criado", entitieMaped);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar contato");
            return StatusCode(500, "Erro ao criar contato");
        }
    }

    [HttpPut("UpdateContact")]
    public async Task<IActionResult> UpdateContact(ContactDto contactDto, Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var entitieMaped = contactMap.ToModel(contactDto);

            var entidadeAtualizada = await _contactService.Update(entitieMaped, id);

            return Ok(entidadeAtualizada);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar dados do contato");
            return StatusCode(500, "Erro ao atualizar dados do contato");

        }
    }

    [HttpDelete("DeleteContact")]
    public async Task<IActionResult> DeleteContact(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            await _contactService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar registro selecionado");
            return StatusCode(500, "Erro ao deletar registro selecionado");
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
            var contact = await _contactService.GetById(id);
            return Ok(contact);
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
            var contacts = await _contactService.GetAll();
            return Ok(contacts);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar registros.");
            return StatusCode(404, "Erro ao listar registros.");
        }
    }
    #endregion
}