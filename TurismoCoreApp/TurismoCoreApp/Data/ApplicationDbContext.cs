using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TurismoCoreApp.Data.Configurations;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Destino> Destinos { get; set; }
    public DbSet<PacoteTuristico> PacotesTuristicos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<PacoteTuristicoDestino> PacoteTuristicoDestinos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplicar todas as configurações
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new DestinoConfiguration());
        modelBuilder.ApplyConfiguration(new PacoteTuristicoConfiguration());
        modelBuilder.ApplyConfiguration(new ReservaConfiguration());
        modelBuilder.ApplyConfiguration(new PacoteTuristicoDestinoConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
