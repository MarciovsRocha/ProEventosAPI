using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly ProEventosContext _context;

    public EventoController(ProEventosContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _context.Eventos.Where(evento => evento.Id == id);
    }
    
    [HttpPost]
    public string Post()
    {
        return "value_POST";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return $"Exemplo de PUT com id = {id}";
    }

    [HttpDelete("{id}")] 
    public string Delete(int id)
    {
        return $"Exemplo de DELETE com id = {id}";
    }
    
}

