using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RaizesNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDadosIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Setor",
                table: "Usuario",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Ativo", "CriadoPor", "DataCriacao", "Nome" },
                values: new object[] { 1L, true, null, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Raízes do Nordeste - Recife" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "CriadoPor", "DataCriacao", "Email", "Nome", "PerfilId", "SenhaHash", "Setor", "UnidadeId" },
                values: new object[] { 1L, true, null, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "sistema@raizes.local", "Sistema", 1L, "AQAAAAIAAYagAAAAEELYqfAH/8I1+eYUiig3UZ6Y8HIYlBAXboQowZcs5MUYtgFqPG6MX3MzEe8PLLVeuA==", null, null });

            migrationBuilder.InsertData(
                table: "Cardapio",
                columns: new[] { "Id", "Ativo", "CriadoPor", "DataCriacao", "Nome", "UnidadeId" },
                values: new object[] { 1L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Cardápio Recife", 1L });

            migrationBuilder.InsertData(
                table: "Estoque",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "UnidadeId" },
                values: new object[] { 1L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 1L });

            migrationBuilder.InsertData(
                table: "ItemInventario",
                columns: new[] { "Id", "Ativo", "CriadoPor", "DataCriacao", "Nome", "Tipo", "UnidadeMedida" },
                values: new object[,]
                {
                    { 1L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Arroz", "Ingrediente", "g" },
                    { 2L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Feijão", "Ingrediente", "g" },
                    { 3L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Carne de Sol", "Ingrediente", "g" },
                    { 4L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Macaxeira", "Ingrediente", "g" },
                    { 5L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Flocão de Milho", "Ingrediente", "g" },
                    { 6L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Água Mineral", "Produto", "un" }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Ativo", "CriadoPor", "DataCriacao", "Descricao", "Nome", "TipoProduto", "ValorUnitario" },
                values: new object[,]
                {
                    { 1L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Baião de dois tradicional", "Baião de Dois", "Preparado", 24.90m },
                    { 2L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Carne de sol acompanhada de macaxeira", "Carne de Sol com Macaxeira", "Preparado", 34.90m },
                    { 3L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Cuscuz tradicional nordestino", "Cuscuz Nordestino", "Preparado", 16.90m },
                    { 4L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Água mineral sem gás", "Água Mineral", "Unitario", 5.00m }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "CriadoPor", "DataCriacao", "Email", "Nome", "PerfilId", "SenhaHash", "Setor", "UnidadeId" },
                values: new object[,]
                {
                    { 2L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "admin@raizes.local", "Administrador", 2L, "AQAAAAIAAYagAAAAEHfNVxWoKHvZf17Kd1QRBwYzG0mHnVfsQc5YD9vOt0kzsc0bC1rd1PMzsN+NrlXp0w==", null, null },
                    { 3L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "funcionario@raizes.local", "Funcionário Atendimento", 3L, "AQAAAAIAAYagAAAAEF89v0rZfLcKRzyyrtF5ta0Ni/9+rXPBUdagtzjp+Au7FPTCd1BfkFyAH7syokH9fw==", "Atendimento", 1L },
                    { 4L, true, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "cliente@raizes.local", "Cliente Teste", 4L, "AQAAAAIAAYagAAAAEDPlUNmZtkC3zUJ1RN4CubcAFyDUC69Mc/nXGqGwo7+0d9e3r1ELSXFuWfkZqeOWeA==", null, null }
                });

            migrationBuilder.InsertData(
                table: "CardapioItem",
                columns: new[] { "Id", "Ativo", "CardapioId", "CriadoPor", "DataCriacao", "ProdutoId" },
                values: new object[,]
                {
                    { 1L, true, 1L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 1L },
                    { 2L, true, 1L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 2L },
                    { 3L, true, 1L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 3L },
                    { 4L, true, 1L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 4L }
                });

            migrationBuilder.InsertData(
                table: "ProdutoItemInventario",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "ItemInventarioId", "ProdutoId", "QuantidadeConsumo" },
                values: new object[] { 1L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 6L, 4L, 1 });

            migrationBuilder.InsertData(
                table: "Receita",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "ProdutoId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 1L },
                    { 2L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 2L },
                    { 3L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 3L }
                });

            migrationBuilder.InsertData(
                table: "SaldoEstoque",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "EstoqueId", "ItemInventarioId", "Quantidade", "QuantidadeReservada" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 1L, 1L, 10000, 0 },
                    { 2L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 1L, 2L, 10000, 0 },
                    { 3L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 1L, 3L, 10000, 0 },
                    { 4L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 1L, 4L, 10000, 0 },
                    { 5L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 1L, 5L, 10000, 0 },
                    { 6L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 1L, 6L, 20, 0 }
                });

            migrationBuilder.InsertData(
                table: "ReceitaItem",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "ItemInventarioId", "Quantidade", "ReceitaId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 1L, 150, 1L },
                    { 2L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 2L, 100, 1L },
                    { 3L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 3L, 200, 2L },
                    { 4L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 4L, 200, 2L },
                    { 5L, 1L, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 5L, 150, 3L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ProdutoItemInventario",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Cardapio",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Estoque",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "Setor",
                table: "Usuario");
        }
    }
}
