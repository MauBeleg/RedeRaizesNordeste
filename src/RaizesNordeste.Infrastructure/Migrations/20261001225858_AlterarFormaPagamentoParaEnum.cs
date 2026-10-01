using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaizesNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterarFormaPagamentoParaEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE "Pagamento"
                ALTER COLUMN "FormaPagamento" TYPE integer
                USING "FormaPagamento"::integer;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE "Pagamento"
                ALTER COLUMN "FormaPagamento" TYPE text
                USING "FormaPagamento"::text;
                """);
        }
    }
}