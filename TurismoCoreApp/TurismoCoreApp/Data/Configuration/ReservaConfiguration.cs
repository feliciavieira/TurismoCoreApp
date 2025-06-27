using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Data.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.Property(r => r.Id).HasColumnName("id_reserva");
            builder.Property(r => r.ClienteId).HasColumnName("id_cliente");
            builder.Property(r => r.PacoteTuristicoId).HasColumnName("id_pacote");
            builder.Property(r => r.DataReserva).HasColumnName("data_reserva");
            builder.Property(r => r.NumeroPessoas).HasColumnName("numero_pessoas");
            builder.Property(r => r.ValorTotal).HasColumnName("valor_total").HasPrecision(10, 2);
            builder.Property(r => r.DeletedAt).HasColumnName("deleted_at");

            // Filtro global para exclusão lógica
            builder.HasQueryFilter(r => r.DeletedAt == null);

            // Relacionamentos
            builder.HasOne(r => r.Cliente)
                   .WithMany(c => c.Reservas)
                   .HasForeignKey(r => r.ClienteId);

            builder.HasOne(r => r.PacoteTuristico)
                   .WithMany(p => p.Reservas)
                   .HasForeignKey(r => r.PacoteTuristicoId);

            builder.HasData(
                new Reserva
                {
                    Id = 1,
                    ClienteId = 1,
                    PacoteTuristicoId = 1,
                    DataReserva = new DateTime(2025, 5, 1), // Data fixa
                    NumeroPessoas = 2,
                    ValorTotal = 3000.00m
                },
                new Reserva
                {
                    Id = 2,
                    ClienteId = 2,
                    PacoteTuristicoId = 2,
                    DataReserva = new DateTime(2025, 5, 5), // Data fixa
                    NumeroPessoas = 1,
                    ValorTotal = 4500.00m
                },
                new Reserva
                {
                    Id = 3,
                    ClienteId = 1,
                    PacoteTuristicoId = 3,
                    DataReserva = new DateTime(2025, 5, 10), // Data fixa
                    NumeroPessoas = 3,
                    ValorTotal = 19500.00m
                }
            );
        }
    }
}