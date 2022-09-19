using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Contract;

public interface IEventoPersist
{
    // EVENTOS
    Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
    Task<Evento?> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false);
}