using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private IEnumerable<Evento> _eventos = new Evento[]
    {
        new Evento(){
            EventoID = 1,
            Tema = "Angular 13 e .NET 6",
            Local = "Curitiba",
            Lote = "1 Lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString(CultureInfo.CurrentCulture),
            ImagemURL = "foto.png"
        },
        new Evento(){
            EventoID = 2,
            Tema = "Suas Novidades",
            Local = "São Paulo",
            Lote = "2 Lote",
            QtdPessoas = 550,
            DataEvento = DateTime.Now.AddDays(3).ToString(),
            ImagemURL = "foto1.png"
        },
        new Evento(){
            EventoID = 3,
            Tema = "Outro Evento",
            Local = "Salvador",
            Lote = "3 Lote",
            QtdPessoas = 50,
            DataEvento = DateTime.Now.AddDays(9).ToString(),
            ImagemURL = "foto_salvador.png"
        },
        new Evento(){
            EventoID = 4,
            Tema = "BackEnd Challenges",
            Local = "Curitiba",
            Lote = "4 Lote",
            QtdPessoas = 1050,
            DataEvento = DateTime.Now.AddDays(30).ToString(),
            ImagemURL = "foto_cwp_back.png"
        }
    };
    
    public EventoController() {}

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _eventos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _eventos.Where(evento => evento.EventoID == id);
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

