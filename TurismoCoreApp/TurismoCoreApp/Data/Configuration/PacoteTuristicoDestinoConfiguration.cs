using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Data.Configurations
{
    public class PacoteTuristicoDestinoConfiguration : IEntityTypeConfiguration<PacoteTuristicoDestino>
    {
        public void Configure(EntityTypeBuilder<PacoteTuristicoDestino> builder)
        {
            // Chave composta
            builder.HasKey(ptd => new { ptd.PacoteTuristicoId, ptd.DestinoId });

            // Nomes das colunas
            builder.Property(ptd => ptd.PacoteTuristicoId).HasColumnName("id_pacote");
            builder.Property(ptd => ptd.DestinoId).HasColumnName("id_destino");
            builder.Property(ptd => ptd.OrdemVisita).HasColumnName("ordem_visita");
            builder.Property(ptd => ptd.DiasNoDestino).HasColumnName("dias_no_destino");

            // Relacionamentos
            builder.HasOne(ptd => ptd.PacoteTuristico)
                   .WithMany(p => p.PacoteTuristicoDestinos)
                   .HasForeignKey(ptd => ptd.PacoteTuristicoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ptd => ptd.Destino)
                   .WithMany(d => d.PacoteTuristicoDestinos)
                   .HasForeignKey(ptd => ptd.DestinoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                // Pacote Rio Maravilhoso (ID: 1) - Rio de Janeiro (ID: 1)
                new PacoteTuristicoDestino
                {
                    PacoteTuristicoId = 1,
                    DestinoId = 1,
                    OrdemVisita = 1,
                    DiasNoDestino = 5
                },

                // Pacote Paris Romântica (ID: 2) - Paris (ID: 4)
                new PacoteTuristicoDestino
                {
                    PacoteTuristicoId = 2,
                    DestinoId = 4,
                    OrdemVisita = 1,
                    DiasNoDestino = 7
                },

                // Pacote Tóquio Cultural (ID: 3) - Tóquio (ID: 6)
                new PacoteTuristicoDestino
                {
                    PacoteTuristicoId = 3,
                    DestinoId = 6,
                    OrdemVisita = 1,
                    DiasNoDestino = 10
                }
            );
        }
    }
}