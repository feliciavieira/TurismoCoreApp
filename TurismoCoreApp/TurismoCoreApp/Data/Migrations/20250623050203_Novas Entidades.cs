using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TurismoCoreApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class NovasEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_cliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email_cliente = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    id_destino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.id_destino);
                });

            migrationBuilder.CreateTable(
                name: "PacotesTuristicos",
                columns: table => new
                {
                    id_pacote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo_pacote = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    capacidade_maxima = table.Column<int>(type: "int", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacotesTuristicos", x => x.id_pacote);
                });

            migrationBuilder.CreateTable(
                name: "PacoteTuristicoDestinos",
                columns: table => new
                {
                    id_pacote = table.Column<int>(type: "int", nullable: false),
                    id_destino = table.Column<int>(type: "int", nullable: false),
                    ordem_visita = table.Column<int>(type: "int", nullable: false),
                    dias_no_destino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacoteTuristicoDestinos", x => new { x.id_pacote, x.id_destino });
                    table.ForeignKey(
                        name: "FK_PacoteTuristicoDestinos_Destinos_id_destino",
                        column: x => x.id_destino,
                        principalTable: "Destinos",
                        principalColumn: "id_destino",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacoteTuristicoDestinos_PacotesTuristicos_id_pacote",
                        column: x => x.id_pacote,
                        principalTable: "PacotesTuristicos",
                        principalColumn: "id_pacote",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    id_reserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_pacote = table.Column<int>(type: "int", nullable: false),
                    data_reserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    numero_pessoas = table.Column<int>(type: "int", nullable: false),
                    valor_total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.id_reserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_PacotesTuristicos_id_pacote",
                        column: x => x.id_pacote,
                        principalTable: "PacotesTuristicos",
                        principalColumn: "id_pacote",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id_cliente", "data_cadastro", "deleted_at", "email_cliente", "nome_cliente" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "joao@email.com", "João Silva" },
                    { 2, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "maria@email.com", "Maria Santos" },
                    { 3, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "pedro@email.com", "Pedro Costa" }
                });

            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "id_destino", "cidade", "deleted_at", "descricao", "pais" },
                values: new object[,]
                {
                    { 1, "Rio de Janeiro", null, "Cidade maravilhosa com praias deslumbrantes", "Brasil" },
                    { 2, "São Paulo", null, "Centro financeiro e cultural do Brasil", "Brasil" },
                    { 3, "Salvador", null, "Capital da cultura afro-brasileira", "Brasil" },
                    { 4, "Paris", null, "Cidade luz, capital do romance", "França" },
                    { 5, "Roma", null, "Cidade eterna com história milenar", "Itália" },
                    { 6, "Tóquio", null, "Metrópole moderna com tradições antigas", "Japão" },
                    { 7, "Buenos Aires", null, "Capital do tango e da boa gastronomia", "Argentina" },
                    { 8, "Nova York", null, "A cidade que nunca dorme", "Estados Unidos" },
                    { 9, "Londres", null, "Cidade histórica com arquitetura icônica", "Reino Unido" },
                    { 10, "Barcelona", null, "Cidade mediterrânea com arquitetura única", "Espanha" }
                });

            migrationBuilder.InsertData(
                table: "PacotesTuristicos",
                columns: new[] { "id_pacote", "capacidade_maxima", "data_fim", "data_inicio", "deleted_at", "descricao", "preco", "titulo_pacote" },
                values: new object[,]
                {
                    { 1, 20, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conheça as belezas do Rio de Janeiro", 1500.00m, "Rio Maravilhoso - 5 dias" },
                    { 2, 15, new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Explore a cidade luz com muito romance", 4500.00m, "Paris Romântica - 7 dias" },
                    { 3, 12, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mergulhe na cultura japonesa", 6500.00m, "Tóquio Cultural - 10 dias" }
                });

            migrationBuilder.InsertData(
                table: "PacoteTuristicoDestinos",
                columns: new[] { "id_destino", "id_pacote", "dias_no_destino", "ordem_visita" },
                values: new object[,]
                {
                    { 1, 1, 5, 1 },
                    { 4, 2, 7, 1 },
                    { 6, 3, 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "id_reserva", "id_cliente", "data_reserva", "deleted_at", "numero_pessoas", "id_pacote", "valor_total" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, 3000.00m },
                    { 2, 2, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, 4500.00m },
                    { 3, 1, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 3, 19500.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinos_cidade",
                table: "Destinos",
                column: "cidade");

            migrationBuilder.CreateIndex(
                name: "IX_Destinos_pais",
                table: "Destinos",
                column: "pais");

            migrationBuilder.CreateIndex(
                name: "IX_Destinos_pais_cidade",
                table: "Destinos",
                columns: new[] { "pais", "cidade" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PacoteTuristicoDestinos_id_destino",
                table: "PacoteTuristicoDestinos",
                column: "id_destino");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_id_cliente",
                table: "Reservas",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_id_pacote",
                table: "Reservas",
                column: "id_pacote");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacoteTuristicoDestinos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "PacotesTuristicos");
        }
    }
}
