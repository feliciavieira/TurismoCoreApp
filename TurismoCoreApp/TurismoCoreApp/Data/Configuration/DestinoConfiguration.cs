using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Data.Configurations
{
    public class DestinoConfiguration : IEntityTypeConfiguration<Destino>
    {
        public void Configure(EntityTypeBuilder<Destino> builder)
        {
            builder.Property(d => d.Id).HasColumnName("id_destino");
            builder.Property(d => d.Pais).HasColumnName("pais").HasMaxLength(100);
            builder.Property(d => d.Cidade).HasColumnName("cidade").HasMaxLength(100);
            builder.Property(d => d.DeletedAt).HasColumnName("deleted_at");
            builder.Property(d => d.Descricao).HasColumnName("descricao").HasMaxLength(500);

            // Filtro global para exclusão lógica
            builder.HasQueryFilter(d => d.DeletedAt == null);

            // Índices para melhor performance nas consultas
            builder.HasIndex(d => d.Pais);
            builder.HasIndex(d => d.Cidade);
            builder.HasIndex(d => new { d.Pais, d.Cidade }).IsUnique(); // Evita duplicatas

            // Dados de exemplo
            builder.HasData(
                new Destino { Id = 1, Pais = "Brasil", Cidade = "Rio de Janeiro", Descricao = "Cidade maravilhosa com praias deslumbrantes" },
                new Destino { Id = 2, Pais = "Brasil", Cidade = "São Paulo", Descricao = "Centro financeiro e cultural do Brasil" },
                new Destino { Id = 3, Pais = "Brasil", Cidade = "Salvador", Descricao = "Capital da cultura afro-brasileira" },
                new Destino { Id = 4, Pais = "França", Cidade = "Paris", Descricao = "Cidade luz, capital do romance" },
                new Destino { Id = 5, Pais = "Itália", Cidade = "Roma", Descricao = "Cidade eterna com história milenar" },
                new Destino { Id = 6, Pais = "Japão", Cidade = "Tóquio", Descricao = "Metrópole moderna com tradições antigas" },
                new Destino { Id = 7, Pais = "Argentina", Cidade = "Buenos Aires", Descricao = "Capital do tango e da boa gastronomia" },
                new Destino { Id = 8, Pais = "Estados Unidos", Cidade = "Nova York", Descricao = "A cidade que nunca dorme" },
                new Destino { Id = 9, Pais = "Reino Unido", Cidade = "Londres", Descricao = "Cidade histórica com arquitetura icônica" },
                new Destino { Id = 10, Pais = "Espanha", Cidade = "Barcelona", Descricao = "Cidade mediterrânea com arquitetura única" }
            );
        }
    }
}