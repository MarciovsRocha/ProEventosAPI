using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Context;

public class ProEventosContext : DbContext
{
    public DbSet<Evento> Eventos { get; set; } = null!;
    public DbSet<Lote> Lotes { get; set; } = null!;
    public DbSet<Palestrante> Palestrantes { get; set; } = null!;
    public DbSet<PalestranteEvento> PalestrantesEventos { get; set; } = null!;
    public DbSet<RedeSocial> RedesSociais { get; set; } = null!;

    public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PalestranteEvento>()
            .HasKey(pe => new { pe.EventoId, pe.PalestranteId });
        base.OnModelCreating(modelBuilder);
    }
}