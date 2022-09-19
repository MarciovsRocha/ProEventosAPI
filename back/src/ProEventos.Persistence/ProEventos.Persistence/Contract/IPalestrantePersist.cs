using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Contract;

public interface IPalestrantePersist
{
    // PALESTRANTES
    Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
    Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);
    Task<Palestrante?> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos = false);
}