using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RaizesNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedPerfis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1L, "Perfil utilizado para operações automáticas dentro do sistema", "Sistema" },
                    { 2L, "Perfil com acesso admnistrativo do sistema", "Administrador" },
                    { 3L, "Perfil utilizado pelos funcionários de uma unidade dentro do sistema", "Funcionário" },
                    { 4L, "Perfil utilizado pelos clientes", "Cliente" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
