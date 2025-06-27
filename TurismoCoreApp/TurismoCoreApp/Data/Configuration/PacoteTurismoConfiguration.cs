using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Data.Configurations
{
    public class PacoteTuristicoConfiguration : IEntityTypeConfiguration<PacoteTuristico>
    {
        public void Configure(EntityTypeBuilder<PacoteTuristico> builder)
        {
            builder.Property(p => p.Id).HasColumnName("id_pacote");
            builder.Property(p => p.Titulo).HasColumnName("titulo_pacote").HasMaxLength(200);
            builder.Property(p => p.DataInicio).HasColumnName("data_inicio");
            builder.Property(p => p.DataFim).HasColumnName("data_fim");
            builder.Property(p => p.CapacidadeMaxima).HasColumnName("capacidade_maxima");
            builder.Property(p => p.Preco).HasColumnName("preco").HasPrecision(10, 2);
            builder.Property(p => p.Descricao).HasColumnName("descricao").HasMaxLength(1000);
            builder.Property(p => p.DeletedAt).HasColumnName("deleted_at");

            // Filtro global para exclusão lógica
            builder.HasQueryFilter(p => p.DeletedAt == null);

            builder.HasData(
                new PacoteTuristico
                {
                    Id = 1,
                    Titulo = "Rio Maravilhoso - 5 dias",
                    DataInicio = new DateTime(2025, 6, 1), // Data fixa
                    DataFim = new DateTime(2025, 6, 6),   // Data fixa
                    CapacidadeMaxima = 20,
                    Preco = 1500.00m,
                    Descricao = "Conheça as belezas do Rio de Janeiro"
                },
                new PacoteTuristico
                {
                    Id = 2,
                    Titulo = "Paris Romântica - 7 dias",
                    DataInicio = new DateTime(2025, 7, 15), // Data fixa
                    DataFim = new DateTime(2025, 7, 22),   // Data fixa
                    CapacidadeMaxima = 15,
                    Preco = 4500.00m,
                    Descricao = "Explore a cidade luz com muito romance"
                },
                new PacoteTuristico
                {
                    Id = 3,
                    Titulo = "Tóquio Cultural - 10 dias",
                    DataInicio = new DateTime(2025, 8, 10), // Data fixa
                    DataFim = new DateTime(2025, 8, 20),    // Data fixa
                    CapacidadeMaxima = 12,
                    Preco = 6500.00m,
                    Descricao = "Mergulhe na cultura japonesa"
                }
            );
        }
    }
}
