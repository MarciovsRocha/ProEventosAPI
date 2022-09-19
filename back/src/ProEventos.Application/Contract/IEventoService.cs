using ProEventos.Domain.Models;

namespace ProEventos.Application.Contract;

public interface IEventoService
{
    // Add - Update - Delete
    Task<Evento?> AddEventos(Evento model);
    Task<Evento?> Update(int eventoId, Evento model);
    Task<bool> DeleteEvento(int eventoId);
    // select
    Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
    Task<Evento?> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false);
}