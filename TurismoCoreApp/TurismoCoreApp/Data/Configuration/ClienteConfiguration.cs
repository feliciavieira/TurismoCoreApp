using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Id).HasColumnName("id_cliente");
            builder.Property(c => c.Nome).HasColumnName("nome_cliente").HasMaxLength(100);
            builder.Property(c => c.Email).HasColumnName("email_cliente").HasMaxLength(150);
            builder.Property(c => c.DataCadastro).HasColumnName("data_cadastro");
            builder.Property(c => c.DeletedAt).HasColumnName("deleted_at");

            // Filtro global para exclusão lógica
            builder.HasQueryFilter(c => c.DeletedAt == null);

            builder.HasData(
                new Cliente
                {
                    Id = 1,
                    Nome = "João Silva",
                    Email = "joao@email.com",
                    DataCadastro = new DateTime(2025, 1, 1) // Data fixa
                },
                new Cliente
                {
                    Id = 2,
                    Nome = "Maria Santos",
                    Email = "maria@email.com",
                    DataCadastro = new DateTime(2025, 1, 10) // Data fixa
                },
                new Cliente
                {
                    Id = 3,
                    Nome = "Pedro Costa",
                    Email = "pedro@email.com",
                    DataCadastro = new DateTime(2025, 1, 15) // Data fixa
                }
            );
        }
    }
}