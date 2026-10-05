using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaizesNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCpfDataNascimentoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Usuario",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuario",
                type: "date",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Cpf", "DataNascimento" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Cpf", "DataNascimento" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Cpf", "DataNascimento" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Cpf", "DataNascimento" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Cpf",
                table: "Usuario",
                column: "Cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_Cpf",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Usuario");
        }
    }
}
