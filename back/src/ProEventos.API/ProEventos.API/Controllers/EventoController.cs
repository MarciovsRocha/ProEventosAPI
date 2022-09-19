using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contract;
using ProEventos.Domain.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly IEventoService _eventoService;

    public EventoController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosAsync(true);
            if (null == eventos) return NotFound("Eventos não encontrados."); // return 404 NotFound
            return Ok(eventos); // return status 200 ok
        }
        catch (Exception e)
        {
            // return 500 Internal Server Error
            return StatusCode(
                StatusCodes.Status500InternalServerError
                ,$"Erro ao tentar recuperar eventos. Erro: {e.Message}"
            );
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var evento = await _eventoService.GetEventoByIdAsync(id, true);
            if (null == evento) return NotFound("Evento por Id não encontrado."); // return Status404NotFound
            return Ok(evento); // return status 200 OK
        }
        catch (Exception e)
        {
            // return 500 Internal Server Error
            return StatusCode(
                StatusCodes.Status500InternalServerError
                , $"Erro ao tentar recuperar evento. Erro: {e.Message}"
            );
        }
    }
    
    [HttpGet("tema/{tema}")]
    public async Task<IActionResult> GetByTema(string tema)
    {
        try
        {
            var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            if (null == evento) return NotFound("Eventos por Tema não encontrados."); // return Status404NotFound
            return Ok(evento); // return status 200 OK
        }
        catch (Exception e)
        {
            // return 500 Internal Server Error
            return StatusCode(
                StatusCodes.Status500InternalServerError
                , $"Erro ao tentar recuperar evento. Erro: {e.Message}"
            );
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
        try
        {
            var evento = await _eventoService.AddEventos(model);
            if (null == evento) return BadRequest("Erro ao tentar adicionar evento."); // return 400 Bad Request 
            return Ok(evento); // return 200 Ok
        }
        catch (Exception e)
        {
            // return 500 Internal Server Error
            return StatusCode(
                StatusCodes.Status500InternalServerError
                , $"Erro ao tentar adicionar evento. Erro{e.Message}"
            );
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
        try
        {
            var evento = await _eventoService.Update(id, model);
            if (null == evento) return BadRequest("Erro ao tentar atualizar evento."); // return 400 Bad Request 
            return Ok(evento); // return 200 Ok
        }
        catch (Exception e)
        {
            // return 500 Internal Server Error
            return StatusCode(
                StatusCodes.Status500InternalServerError
                , $"Erro ao tentar atualizar evento. Erro{e.Message}"
            );
        }
    }

    [HttpDelete("{id}")] 
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return await _eventoService.DeleteEvento(id)
                ? Ok("Evento apagado com sucesso.")
                : BadRequest("Evento não apagado.");
        }
        catch (Exception e)
        {
            // return 500 Internal Server Error
            return StatusCode(
                StatusCodes.Status500InternalServerError
                , $"Erro ao tentar apagar evento. Erro{e.Message}"
            );
        }
    }
    
}

