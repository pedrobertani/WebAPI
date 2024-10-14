using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context;

public class TurismoContext : DbContext
{
    public TurismoContext(DbContextOptions<TurismoContext> options) : base(options)
    {
    }

    public DbSet<PontoTuristico> PontoTuristico { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PontoTuristico>()
            .Property(t => t.Descricao)
            .HasMaxLength(100);
    }
}