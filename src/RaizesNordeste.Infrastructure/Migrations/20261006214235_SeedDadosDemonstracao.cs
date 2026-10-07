using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RaizesNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDadosDemonstracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Auditoria",
                columns: new[] { "Id", "Acao", "DataCriacao", "Detalhes", "Entidade", "RegistroId", "UsuarioId" },
                values: new object[,]
                {
                    { 12L, "STATUS_ALTERADO", new DateTime(2026, 10, 1, 19, 15, 0, 0, DateTimeKind.Utc), "Status do pedido alterado para Entregue.", "PEDIDO", 1L, 3L },
                    { 15L, "STATUS_ALTERADO", new DateTime(2026, 10, 4, 19, 5, 0, 0, DateTimeKind.Utc), "Status do pedido alterado para EmPreparo.", "PEDIDO", 4L, 4L }
                });

            migrationBuilder.UpdateData(
                table: "Cardapio",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DataCriacao", "Nome" },
                values: new object[] { new DateTime(2026, 10, 1, 13, 5, 0, 0, DateTimeKind.Utc), "" });

            migrationBuilder.UpdateData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Estoque",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "ItemInventario",
                columns: new[] { "Id", "Ativo", "CriadoPor", "DataCriacao", "Nome", "Tipo", "UnidadeMedida" },
                values: new object[,]
                {
                    { 7L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Queijo Coalho", "Ingrediente", "g" },
                    { 8L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Massa de Mandioca", "Ingrediente", "g" },
                    { 9L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Camarão", "Ingrediente", "g" },
                    { 10L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Feijão-Fradinho", "Ingrediente", "g" },
                    { 11L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Peixe", "Ingrediente", "g" },
                    { 12L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Leite de Coco", "Ingrediente", "ml" },
                    { 13L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Purê de Macaxeira", "Ingrediente", "g" },
                    { 14L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Banana", "Ingrediente", "un" },
                    { 15L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Açúcar", "Ingrediente", "g" },
                    { 16L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Canela", "Ingrediente", "g" },
                    { 17L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Refrigerante Lata", "Produto", "un" },
                    { 18L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Suco de Cajá", "Produto", "un" },
                    { 19L, true, 1L, new DateTime(2026, 10, 1, 12, 35, 0, 0, DateTimeKind.Utc), "Suco de Umbu", "Produto", "un" }
                });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Ativo", "CriadoPor", "DataCriacao", "Descricao", "Nome", "TipoProduto", "ValorUnitario" },
                values: new object[,]
                {
                    { 5L, true, 1L, new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc), "Escondidinho de macaxeira com carne de sol e queijo coalho", "Escondidinho de Carne de Sol", "Preparado", 29.90m },
                    { 6L, true, 1L, new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc), "Acarajé tradicional com camarão", "Acarajé", "Preparado", 18.90m },
                    { 7L, true, 1L, new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc), "Moqueca de peixe com camarão e leite de coco", "Moqueca Baiana", "Preparado", 39.90m },
                    { 8L, true, 1L, new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc), "Tapioca recheada com queijo coalho", "Tapioca de Queijo Coalho", "Preparado", 15.90m },
                    { 9L, true, 1L, new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc), "Sobremesa de banana com queijo coalho, açúcar e canela", "Cartola", "Preparado", 14.90m },
                    { 10L, true, 1L, new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc), "Refrigerante em lata", "Refrigerante Lata", "Unitario", 7.00m },
                    { 11L, true, 1L, new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc), "Suco de cajá pronto para consumo", "Suco de Cajá", "Unitario", 8.00m },
                    { 12L, true, 1L, new DateTime(2026, 10, 1, 12, 45, 0, 0, DateTimeKind.Utc), "Suco de umbu pronto para consumo", "Suco de Umbu", "Unitario", 8.00m }
                });

            migrationBuilder.UpdateData(
               table: "CardapioItem",
               keyColumn: "Id",
               keyValue: 4L,
               columns: new[] { "DataCriacao", "ProdutoId" },
               values: new object[] { new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 5L });

            migrationBuilder.InsertData(
               table: "CardapioItem",
               columns: new[] { "Id", "Ativo", "CardapioId", "CriadoPor", "DataCriacao", "ProdutoId" },
               values: new object[] { 7L, true, 1L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 4L });


            migrationBuilder.UpdateData(
                table: "ProdutoItemInventario",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 13, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DataCriacao", "ItemInventarioId", "Quantidade", "ReceitaId" },
                values: new object[] { new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 7L, 50, 1L });

            migrationBuilder.UpdateData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DataCriacao", "ItemInventarioId" },
                values: new object[] { new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 3L });

            migrationBuilder.UpdateData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DataCriacao", "ItemInventarioId", "Quantidade", "ReceitaId" },
                values: new object[] { new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 4L, 200, 2L });

            migrationBuilder.InsertData(
                table: "ReceitaItem",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "ItemInventarioId", "Quantidade", "ReceitaId" },
                values: new object[] { 6L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 5L, 150, 3L });

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DataCriacao", "Quantidade" },
                values: new object[] { new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 20000 });

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DataCriacao", "Quantidade" },
                values: new object[] { new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 15000 });

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DataCriacao", "Quantidade" },
                values: new object[] { new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 12000 });

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DataCriacao", "Quantidade" },
                values: new object[] { new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 15000 });

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DataCriacao", "Quantidade" },
                values: new object[] { new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 60 });

            migrationBuilder.UpdateData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Ativo", "CriadoPor", "DataCriacao", "Nome" },
                values: new object[,]
                {
                    { 2L, true, null, new DateTime(2026, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Raízes do Nordeste - Salvador" },
                    { 3L, true, null, new DateTime(2026, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Raízes do Nordeste - Fortaleza" }
                });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DataCriacao", "SenhaHash" },
                values: new object[] { new DateTime(2026, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEHfOA8Co7qyl63HqVLQ1cqCF8AtGeHVgOF4cq9NQv2eghCoPEJgZLGu85y8EQ4aiow==" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DataCriacao", "SenhaHash" },
                values: new object[] { new DateTime(2026, 10, 1, 12, 5, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEJj8/fMqEpLneFB1tluL56efVKodwkkR5hglovNbLUfM9fR14RfYolR+fAe2kIwTnA==" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Cpf", "DataCriacao", "DataNascimento", "Email", "Nome", "SenhaHash" },
                values: new object[] { "00000000001", new DateTime(2026, 10, 1, 12, 10, 0, 0, DateTimeKind.Utc), new DateTime(1992, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "rafael.oliveira@raizes.local", "Rafael Oliveira", "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Cpf", "DataCriacao", "DataNascimento", "Email", "Nome", "PerfilId", "SenhaHash", "Setor", "UnidadeId" },
                values: new object[] { "00000000002", new DateTime(2026, 10, 1, 12, 11, 0, 0, DateTimeKind.Utc), new DateTime(1995, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "juliana.santos@raizes.local", "Juliana Santos", 3L, "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==", "Cozinha", 1L });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "Cpf", "CriadoPor", "DataCriacao", "DataNascimento", "Email", "Nome", "PerfilId", "SenhaHash", "Setor", "UnidadeId" },
                values: new object[,]
                {
                    { 9L, true, "00000000007", 1L, new DateTime(2026, 10, 1, 12, 20, 0, 0, DateTimeKind.Utc), new DateTime(1998, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana.souza@demo.local", "Ana Souza", 4L, "AQAAAAIAAYagAAAAEG0asrp6NVUc19UatFt4ocTMUHJYjQNMTOIzZnAeE4SV747XQMOA95vsrG4SRUt0tg==", null, null },
                    { 10L, true, "00000000008", 1L, new DateTime(2026, 10, 1, 12, 21, 0, 0, DateTimeKind.Utc), new DateTime(1986, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos.lima@demo.local", "Carlos Lima", 4L, "AQAAAAIAAYagAAAAEG0asrp6NVUc19UatFt4ocTMUHJYjQNMTOIzZnAeE4SV747XQMOA95vsrG4SRUt0tg==", null, null },
                    { 11L, true, "00000000009", 1L, new DateTime(2026, 10, 1, 12, 22, 0, 0, DateTimeKind.Utc), new DateTime(1993, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "fernanda.rocha@demo.local", "Fernanda Rocha", 4L, "AQAAAAIAAYagAAAAEG0asrp6NVUc19UatFt4ocTMUHJYjQNMTOIzZnAeE4SV747XQMOA95vsrG4SRUt0tg==", null, null },
                    { 12L, true, "00000000010", 1L, new DateTime(2026, 10, 1, 12, 23, 0, 0, DateTimeKind.Utc), new DateTime(1996, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedro.martins@demo.local", "Pedro Martins", 4L, "AQAAAAIAAYagAAAAEG0asrp6NVUc19UatFt4ocTMUHJYjQNMTOIzZnAeE4SV747XQMOA95vsrG4SRUt0tg==", null, null }
                });

            migrationBuilder.InsertData(
                table: "Auditoria",
                columns: new[] { "Id", "Acao", "DataCriacao", "Detalhes", "Entidade", "RegistroId", "UsuarioId" },
                values: new object[,]
                {
                    { 1L, "PEDIDO_CRIADO", new DateTime(2026, 10, 1, 18, 30, 0, 0, DateTimeKind.Utc), "Pedido criado pelo cliente.", "PEDIDO", 1L, 9L },
                    { 2L, "PEDIDO_CRIADO", new DateTime(2026, 10, 2, 19, 10, 0, 0, DateTimeKind.Utc), "Pedido criado pelo cliente.", "PEDIDO", 2L, 10L },
                    { 3L, "PEDIDO_CRIADO", new DateTime(2026, 10, 3, 20, 0, 0, 0, DateTimeKind.Utc), "Pedido criado pelo cliente.", "PEDIDO", 3L, 11L },
                    { 4L, "PEDIDO_CRIADO", new DateTime(2026, 10, 4, 18, 45, 0, 0, DateTimeKind.Utc), "Pedido criado pelo cliente.", "PEDIDO", 4L, 12L },
                    { 5L, "PEDIDO_CRIADO", new DateTime(2026, 10, 5, 19, 20, 0, 0, DateTimeKind.Utc), "Pedido criado pelo cliente.", "PEDIDO", 5L, 9L },
                    { 6L, "PEDIDO_CRIADO", new DateTime(2026, 10, 6, 20, 15, 0, 0, DateTimeKind.Utc), "Pedido criado pelo cliente.", "PEDIDO", 6L, 10L },
                    { 7L, "PAGAMENTO_PROCESSADO", new DateTime(2026, 10, 1, 18, 32, 0, 0, DateTimeKind.Utc), "Pagamento processado com sucesso.", "PEDIDO", 1L, 9L },
                    { 8L, "PAGAMENTO_PROCESSADO", new DateTime(2026, 10, 2, 19, 12, 0, 0, DateTimeKind.Utc), "Pagamento processado com sucesso.", "PEDIDO", 2L, 10L },
                    { 9L, "PAGAMENTO_PROCESSADO", new DateTime(2026, 10, 3, 20, 2, 0, 0, DateTimeKind.Utc), "Pagamento processado com sucesso.", "PEDIDO", 3L, 11L },
                    { 10L, "PAGAMENTO_PROCESSADO", new DateTime(2026, 10, 4, 18, 47, 0, 0, DateTimeKind.Utc), "Pagamento processado com sucesso.", "PEDIDO", 4L, 12L },
                    { 11L, "PAGAMENTO_PROCESSADO", new DateTime(2026, 10, 5, 19, 22, 0, 0, DateTimeKind.Utc), "Pagamento processado com sucesso.", "PEDIDO", 5L, 9L }
                });

            migrationBuilder.InsertData(
                table: "Cardapio",
                columns: new[] { "Id", "Ativo", "CriadoPor", "DataCriacao", "Nome", "UnidadeId" },
                values: new object[,]
                {
                    { 2L, true, 1L, new DateTime(2026, 10, 1, 13, 5, 0, 0, DateTimeKind.Utc), "", 2L },
                    { 3L, true, 1L, new DateTime(2026, 10, 1, 13, 5, 0, 0, DateTimeKind.Utc), "", 3L }
                });

            migrationBuilder.InsertData(
                table: "CardapioItem",
                columns: new[] { "Id", "Ativo", "CardapioId", "CriadoPor", "DataCriacao", "ProdutoId" },
                values: new object[,]
                {
                    { 5L, true, 1L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 8L },
                    { 6L, true, 1L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 9L },
                    { 8L, true, 1L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 10L },
                    { 9L, true, 1L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 11L }
                });

            migrationBuilder.InsertData(
                table: "Consentimento",
                columns: new[] { "Id", "Aceito", "CriadoPor", "DataCriacao", "TipoConsentimento", "UsuarioId" },
                values: new object[,]
                {
                    { 1L, true, 9L, new DateTime(2026, 10, 1, 18, 0, 0, 0, DateTimeKind.Utc), "FIDELIZACAO", 9L },
                    { 2L, false, 10L, new DateTime(2026, 10, 2, 18, 30, 0, 0, DateTimeKind.Utc), "CAMPANHAS", 10L },
                    { 3L, true, 11L, new DateTime(2026, 10, 3, 19, 20, 0, 0, DateTimeKind.Utc), "CAMPANHAS", 11L }
                });

            migrationBuilder.InsertData(
                table: "Estoque",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "UnidadeId" },
                values: new object[,]
                {
                    { 2L, 1L, new DateTime(2026, 10, 1, 12, 30, 0, 0, DateTimeKind.Utc), 2L },
                    { 3L, 1L, new DateTime(2026, 10, 1, 12, 30, 0, 0, DateTimeKind.Utc), 3L }
                });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "CanalPedido", "ClienteId", "CriadoPor", "DataCriacao", "Desconto", "Status", "Subtotal", "UnidadeId", "ValorTotal" },
                values: new object[,]
                {
                    { 1L, "App", 9L, 9L, new DateTime(2026, 10, 1, 18, 30, 0, 0, DateTimeKind.Utc), 0.00m, "Entregue", 29.90m, 1L, 29.90m },
                    { 2L, "Web", 10L, 10L, new DateTime(2026, 10, 2, 19, 10, 0, 0, DateTimeKind.Utc), 0.00m, "Entregue", 46.90m, 2L, 46.90m },
                    { 3L, "App", 11L, 11L, new DateTime(2026, 10, 3, 20, 0, 0, 0, DateTimeKind.Utc), 0.00m, "Pronto", 42.90m, 3L, 42.90m },
                    { 4L, "Web", 12L, 12L, new DateTime(2026, 10, 4, 18, 45, 0, 0, DateTimeKind.Utc), 0.00m, "EmPreparo", 44.80m, 1L, 44.80m },
                    { 5L, "App", 9L, 9L, new DateTime(2026, 10, 5, 19, 20, 0, 0, DateTimeKind.Utc), 0.00m, "Recebido", 42.80m, 2L, 42.80m },
                    { 6L, "Web", 10L, 10L, new DateTime(2026, 10, 6, 20, 15, 0, 0, DateTimeKind.Utc), 0.00m, "AguardandoPagamento", 23.90m, 3L, 23.90m }
                });

            migrationBuilder.InsertData(
                table: "ProdutoItemInventario",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "ItemInventarioId", "ProdutoId", "QuantidadeConsumo" },
                values: new object[,]
                {
                    { 2L, 1L, new DateTime(2026, 10, 1, 13, 0, 0, 0, DateTimeKind.Utc), 17L, 10L, 1 },
                    { 3L, 1L, new DateTime(2026, 10, 1, 13, 0, 0, 0, DateTimeKind.Utc), 18L, 11L, 1 },
                    { 4L, 1L, new DateTime(2026, 10, 1, 13, 0, 0, 0, DateTimeKind.Utc), 19L, 12L, 1 }
                });

            migrationBuilder.InsertData(
                table: "Receita",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "ProdutoId" },
                values: new object[,]
                {
                    { 4L, 1L, new DateTime(2026, 10, 1, 12, 50, 0, 0, DateTimeKind.Utc), 5L },
                    { 5L, 1L, new DateTime(2026, 10, 1, 12, 50, 0, 0, DateTimeKind.Utc), 6L },
                    { 6L, 1L, new DateTime(2026, 10, 1, 12, 50, 0, 0, DateTimeKind.Utc), 7L },
                    { 7L, 1L, new DateTime(2026, 10, 1, 12, 50, 0, 0, DateTimeKind.Utc), 8L },
                    { 8L, 1L, new DateTime(2026, 10, 1, 12, 50, 0, 0, DateTimeKind.Utc), 9L }
                });

            migrationBuilder.InsertData(
                table: "ReceitaItem",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "ItemInventarioId", "Quantidade", "ReceitaId" },
                values: new object[] { 7L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 7L, 50, 3L });

            migrationBuilder.InsertData(
                table: "SaldoEstoque",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "EstoqueId", "ItemInventarioId", "Quantidade", "QuantidadeReservada" },
                values: new object[,]
                {
                    { 7L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 7L, 8000, 0 },
                    { 8L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 8L, 8000, 0 },
                    { 9L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 9L, 6000, 0 },
                    { 10L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 10L, 5000, 0 },
                    { 11L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 11L, 6000, 0 },
                    { 12L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 12L, 8000, 0 },
                    { 13L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 13L, 8000, 0 },
                    { 14L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 14L, 50, 0 },
                    { 15L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 15L, 5000, 0 },
                    { 16L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 16L, 1000, 0 },
                    { 17L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 17L, 50, 0 },
                    { 18L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 18L, 40, 0 },
                    { 19L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 1L, 19L, 30, 0 }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "Cpf", "CriadoPor", "DataCriacao", "DataNascimento", "Email", "Nome", "PerfilId", "SenhaHash", "Setor", "UnidadeId" },
                values: new object[,]
                {
                    { 5L, true, "00000000003", 1L, new DateTime(2026, 10, 1, 12, 12, 0, 0, DateTimeKind.Utc), new DateTime(1990, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucas.almeida@raizes.local", "Lucas Almeida", 3L, "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==", "Atendimento", 2L },
                    { 6L, true, "00000000004", 1L, new DateTime(2026, 10, 1, 12, 13, 0, 0, DateTimeKind.Utc), new DateTime(1994, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "camila.ferreira@raizes.local", "Camila Ferreira", 3L, "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==", "Cozinha", 2L },
                    { 7L, true, "00000000005", 1L, new DateTime(2026, 10, 1, 12, 14, 0, 0, DateTimeKind.Utc), new DateTime(1989, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "bruno.carvalho@raizes.local", "Bruno Carvalho", 3L, "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==", "Atendimento", 3L },
                    { 8L, true, "00000000006", 1L, new DateTime(2026, 10, 1, 12, 15, 0, 0, DateTimeKind.Utc), new DateTime(1987, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariana.costa@raizes.local", "Mariana Costa", 3L, "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==", "Gerencia", 3L }
                });

            migrationBuilder.InsertData(
                table: "Auditoria",
                columns: new[] { "Id", "Acao", "DataCriacao", "Detalhes", "Entidade", "RegistroId", "UsuarioId" },
                values: new object[,]
                {
                    { 13L, "STATUS_ALTERADO", new DateTime(2026, 10, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Status do pedido alterado para Entregue.", "PEDIDO", 2L, 5L },
                    { 14L, "STATUS_ALTERADO", new DateTime(2026, 10, 3, 20, 40, 0, 0, DateTimeKind.Utc), "Status do pedido alterado para Pronto.", "PEDIDO", 3L, 7L }
                });

            migrationBuilder.InsertData(
                table: "CardapioItem",
                columns: new[] { "Id", "Ativo", "CardapioId", "CriadoPor", "DataCriacao", "ProdutoId" },
                values: new object[,]
                {
                    { 10L, true, 2L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 1L },
                    { 11L, true, 2L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 6L },
                    { 12L, true, 2L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 7L },
                    { 13L, true, 2L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 3L },
                    { 14L, true, 2L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 9L },
                    { 15L, true, 2L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 4L },
                    { 16L, true, 2L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 10L },
                    { 17L, true, 2L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 12L },
                    { 18L, true, 3L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 1L },
                    { 19L, true, 3L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 2L },
                    { 20L, true, 3L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 3L },
                    { 21L, true, 3L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 8L },
                    { 22L, true, 3L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 5L },
                    { 23L, true, 3L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 4L },
                    { 24L, true, 3L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 10L },
                    { 25L, true, 3L, 1L, new DateTime(2026, 10, 1, 13, 10, 0, 0, DateTimeKind.Utc), 11L }
                });

            migrationBuilder.InsertData(
                table: "Pagamento",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "FormaPagamento", "IdentificadorExterno", "PedidoId", "Status", "Valor" },
                values: new object[,]
                {
                    { 1L, 9L, new DateTime(2026, 10, 1, 18, 32, 0, 0, DateTimeKind.Utc), 0, "MOCK-PAG-0001", 1L, "Aprovado", 29.90m },
                    { 2L, 10L, new DateTime(2026, 10, 2, 19, 12, 0, 0, DateTimeKind.Utc), 1, "MOCK-PAG-0002", 2L, "Aprovado", 46.90m },
                    { 3L, 11L, new DateTime(2026, 10, 3, 20, 2, 0, 0, DateTimeKind.Utc), 2, "MOCK-PAG-0003", 3L, "Aprovado", 42.90m },
                    { 4L, 12L, new DateTime(2026, 10, 4, 18, 47, 0, 0, DateTimeKind.Utc), 0, "MOCK-PAG-0004", 4L, "Aprovado", 44.80m },
                    { 5L, 9L, new DateTime(2026, 10, 5, 19, 22, 0, 0, DateTimeKind.Utc), 1, "MOCK-PAG-0005", 5L, "Aprovado", 42.80m }
                });

            migrationBuilder.InsertData(
                table: "PedidoItem",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "PedidoId", "ProdutoId", "Quantidade", "ValorTotal", "ValorUnitario" },
                values: new object[,]
                {
                    { 1L, 9L, new DateTime(2026, 10, 1, 18, 30, 0, 0, DateTimeKind.Utc), 1L, 1L, 1, 24.90m, 24.90m },
                    { 2L, 9L, new DateTime(2026, 10, 1, 18, 30, 0, 0, DateTimeKind.Utc), 1L, 4L, 1, 5.00m, 5.00m },
                    { 3L, 10L, new DateTime(2026, 10, 2, 19, 10, 0, 0, DateTimeKind.Utc), 2L, 7L, 1, 39.90m, 39.90m },
                    { 4L, 10L, new DateTime(2026, 10, 2, 19, 10, 0, 0, DateTimeKind.Utc), 2L, 10L, 1, 7.00m, 7.00m },
                    { 5L, 11L, new DateTime(2026, 10, 3, 20, 0, 0, 0, DateTimeKind.Utc), 3L, 2L, 1, 34.90m, 34.90m },
                    { 6L, 11L, new DateTime(2026, 10, 3, 20, 0, 0, 0, DateTimeKind.Utc), 3L, 11L, 1, 8.00m, 8.00m },
                    { 7L, 12L, new DateTime(2026, 10, 4, 18, 45, 0, 0, DateTimeKind.Utc), 4L, 5L, 1, 29.90m, 29.90m },
                    { 8L, 12L, new DateTime(2026, 10, 4, 18, 45, 0, 0, DateTimeKind.Utc), 4L, 9L, 1, 14.90m, 14.90m },
                    { 9L, 9L, new DateTime(2026, 10, 5, 19, 20, 0, 0, DateTimeKind.Utc), 5L, 6L, 2, 37.80m, 18.90m },
                    { 10L, 9L, new DateTime(2026, 10, 5, 19, 20, 0, 0, DateTimeKind.Utc), 5L, 4L, 1, 5.00m, 5.00m },
                    { 11L, 10L, new DateTime(2026, 10, 6, 20, 15, 0, 0, DateTimeKind.Utc), 6L, 3L, 1, 16.90m, 16.90m },
                    { 12L, 10L, new DateTime(2026, 10, 6, 20, 15, 0, 0, DateTimeKind.Utc), 6L, 10L, 1, 7.00m, 7.00m }
                });

            migrationBuilder.InsertData(
                table: "ReceitaItem",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "ItemInventarioId", "Quantidade", "ReceitaId" },
                values: new object[,]
                {
                    { 8L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 13L, 200, 4L },
                    { 9L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 3L, 150, 4L },
                    { 10L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 7L, 50, 4L },
                    { 11L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 10L, 150, 5L },
                    { 12L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 9L, 80, 5L },
                    { 13L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 11L, 200, 6L },
                    { 14L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 12L, 100, 6L },
                    { 15L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 9L, 80, 6L },
                    { 16L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 8L, 120, 7L },
                    { 17L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 7L, 80, 7L },
                    { 18L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 14L, 1, 8L },
                    { 19L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 7L, 80, 8L },
                    { 20L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 15L, 20, 8L },
                    { 21L, 1L, new DateTime(2026, 10, 1, 12, 55, 0, 0, DateTimeKind.Utc), 16L, 5, 8L }
                });

            migrationBuilder.InsertData(
                table: "SaldoEstoque",
                columns: new[] { "Id", "CriadoPor", "DataCriacao", "EstoqueId", "ItemInventarioId", "Quantidade", "QuantidadeReservada" },
                values: new object[,]
                {
                    { 20L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 1L, 15000, 0 },
                    { 21L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 2L, 10000, 0 },
                    { 22L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 3L, 6000, 0 },
                    { 23L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 4L, 8000, 0 },
                    { 24L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 5L, 8000, 0 },
                    { 25L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 6L, 50, 0 },
                    { 26L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 7L, 6000, 0 },
                    { 27L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 8L, 5000, 0 },
                    { 28L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 9L, 10000, 0 },
                    { 29L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 10L, 12000, 0 },
                    { 30L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 11L, 12000, 0 },
                    { 31L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 12L, 10000, 0 },
                    { 32L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 13L, 5000, 0 },
                    { 33L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 14L, 40, 0 },
                    { 34L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 15L, 4000, 0 },
                    { 35L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 16L, 800, 0 },
                    { 36L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 17L, 40, 0 },
                    { 37L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 18L, 30, 0 },
                    { 38L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 2L, 19L, 50, 0 },
                    { 39L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 1L, 18000, 0 },
                    { 40L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 2L, 14000, 0 },
                    { 41L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 3L, 15000, 0 },
                    { 42L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 4L, 18000, 0 },
                    { 43L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 5L, 15000, 0 },
                    { 44L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 6L, 50, 0 },
                    { 45L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 7L, 10000, 0 },
                    { 46L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 8L, 10000, 0 },
                    { 47L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 9L, 5000, 0 },
                    { 48L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 10L, 5000, 0 },
                    { 49L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 11L, 5000, 0 },
                    { 50L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 12L, 5000, 0 },
                    { 51L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 13L, 10000, 0 },
                    { 52L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 14L, 40, 0 },
                    { 53L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 15L, 4000, 0 },
                    { 54L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 16L, 800, 0 },
                    { 55L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 17L, 50, 0 },
                    { 56L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 18L, 50, 0 },
                    { 57L, 1L, new DateTime(2026, 10, 1, 12, 40, 0, 0, DateTimeKind.Utc), 3L, 19L, 30, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Consentimento",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Consentimento",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Consentimento",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Pagamento",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Pagamento",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Pagamento",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Pagamento",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Pagamento",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "PedidoItem",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "ProdutoItemInventario",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProdutoItemInventario",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProdutoItemInventario",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Cardapio",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cardapio",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Estoque",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Estoque",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.UpdateData(
                table: "Cardapio",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DataCriacao", "Nome" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "Cardápio Recife" });

            migrationBuilder.UpdateData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "CardapioItem",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DataCriacao", "ProdutoId" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 4L });

            migrationBuilder.UpdateData(
                table: "Estoque",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ItemInventario",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ProdutoItemInventario",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DataCriacao", "ItemInventarioId", "Quantidade", "ReceitaId" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 3L, 200, 2L });

            migrationBuilder.UpdateData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DataCriacao", "ItemInventarioId" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 4L });

            migrationBuilder.UpdateData(
                table: "ReceitaItem",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DataCriacao", "ItemInventarioId", "Quantidade", "ReceitaId" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 5L, 150, 3L });

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DataCriacao", "Quantidade" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 10000 });

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DataCriacao", "Quantidade" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 10000 });

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DataCriacao", "Quantidade" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 10000 });

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DataCriacao", "Quantidade" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 10000 });

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "SaldoEstoque",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DataCriacao", "Quantidade" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), 20 });

            migrationBuilder.UpdateData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DataCriacao", "SenhaHash" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEELYqfAH/8I1+eYUiig3UZ6Y8HIYlBAXboQowZcs5MUYtgFqPG6MX3MzEe8PLLVeuA==" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DataCriacao", "SenhaHash" },
                values: new object[] { new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEHfNVxWoKHvZf17Kd1QRBwYzG0mHnVfsQc5YD9vOt0kzsc0bC1rd1PMzsN+NrlXp0w==" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Cpf", "DataCriacao", "DataNascimento", "Email", "Nome", "SenhaHash" },
                values: new object[] { null, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), null, "funcionario@raizes.local", "Funcionário Atendimento", "AQAAAAIAAYagAAAAEF89v0rZfLcKRzyyrtF5ta0Ni/9+rXPBUdagtzjp+Au7FPTCd1BfkFyAH7syokH9fw==" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Cpf", "DataCriacao", "DataNascimento", "Email", "Nome", "PerfilId", "SenhaHash", "Setor", "UnidadeId" },
                values: new object[] { null, new DateTime(2026, 9, 22, 22, 3, 50, 0, DateTimeKind.Utc), null, "cliente@raizes.local", "Cliente Teste", 4L, "AQAAAAIAAYagAAAAEDPlUNmZtkC3zUJ1RN4CubcAFyDUC69Mc/nXGqGwo7+0d9e3r1ELSXFuWfkZqeOWeA==", null, null });
        }
    }
}
