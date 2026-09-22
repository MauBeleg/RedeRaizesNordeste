using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RaizesNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auditoria",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    Acao = table.Column<string>(type: "text", nullable: false),
                    Entidade = table.Column<string>(type: "text", nullable: false),
                    RegistroId = table.Column<long>(type: "bigint", nullable: false),
                    Detalhes = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cardapio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    UnidadeId = table.Column<long>(type: "bigint", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardapioItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardapioId = table.Column<long>(type: "bigint", nullable: false),
                    ProdutoId = table.Column<long>(type: "bigint", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardapioItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardapioItem_Cardapio_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "Cardapio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consentimento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    TipoConsentimento = table.Column<string>(type: "text", nullable: false),
                    Aceito = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consentimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnidadeId = table.Column<long>(type: "bigint", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemInventario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInventario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PedidoId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    FormaPagamento = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    IdentificadorExterno = table.Column<string>(type: "text", nullable: true),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.CheckConstraint("CK_Pagamento_Valor", "\"Valor\" >= 0");
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    UnidadeId = table.Column<long>(type: "bigint", nullable: false),
                    CanalPedido = table.Column<string>(type: "text", nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Desconto = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.CheckConstraint("CK_Pedido_Desconto", "\"Desconto\" >= 0");
                    table.CheckConstraint("CK_Pedido_Subtotal", "\"Subtotal\" >= 0");
                    table.CheckConstraint("CK_Pedido_ValorTotal", "\"ValorTotal\" >= 0");
                });

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PedidoId = table.Column<long>(type: "bigint", nullable: false),
                    ProdutoId = table.Column<long>(type: "bigint", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.Id);
                    table.CheckConstraint("CK_PedidoItem_Quantidade", "\"Quantidade\" > 0");
                    table.CheckConstraint("CK_PedidoItem_ValorTotal", "\"ValorTotal\" > 0");
                    table.CheckConstraint("CK_PedidoItem_ValorUnitario", "\"ValorUnitario\" > 0");
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PontosCliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    Pontos = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PontosHistorico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PontosClienteId = table.Column<long>(type: "bigint", nullable: false),
                    PedidoId = table.Column<long>(type: "bigint", nullable: true),
                    RegraResgateId = table.Column<long>(type: "bigint", nullable: true),
                    TipoMovimentacao = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosHistorico", x => x.Id);
                    table.CheckConstraint("CK_PontosHistorico_Quantidade", "\"Quantidade\" > 0");
                    table.ForeignKey(
                        name: "FK_PontosHistorico_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PontosHistorico_PontosCliente_PontosClienteId",
                        column: x => x.PontosClienteId,
                        principalTable: "PontosCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    ValorUnitario = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    TipoProduto = table.Column<string>(type: "text", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.CheckConstraint("CK_Produto_ValorUnitario", "\"ValorUnitario\" > 0");
                });

            migrationBuilder.CreateTable(
                name: "ProdutoItemInventario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutoId = table.Column<long>(type: "bigint", nullable: false),
                    ItemInventarioId = table.Column<long>(type: "bigint", nullable: false),
                    QuantidadeConsumo = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoItemInventario", x => x.Id);
                    table.CheckConstraint("CK_ProdutoItemInventario_QuantidadeConsumo", "\"QuantidadeConsumo\" > 0");
                    table.ForeignKey(
                        name: "FK_ProdutoItemInventario_ItemInventario_ItemInventarioId",
                        column: x => x.ItemInventarioId,
                        principalTable: "ItemInventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutoItemInventario_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutoId = table.Column<long>(type: "bigint", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receita_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceitaItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReceitaId = table.Column<long>(type: "bigint", nullable: false),
                    ItemInventarioId = table.Column<long>(type: "bigint", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaItem", x => x.Id);
                    table.CheckConstraint("CK_ReceitaItem_Quantidade", "\"Quantidade\" > 0");
                    table.ForeignKey(
                        name: "FK_ReceitaItem_ItemInventario_ItemInventarioId",
                        column: x => x.ItemInventarioId,
                        principalTable: "ItemInventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceitaItem_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegraResgatePontos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    PontosNecessarios = table.Column<int>(type: "integer", nullable: false),
                    PercentualDesconto = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegraResgatePontos", x => x.Id);
                    table.CheckConstraint("CK_RegraResgatePontos_PercentualDesconto", "\"PercentualDesconto\" > 0 AND \"PercentualDesconto\" <= 100");
                    table.CheckConstraint("CK_RegraResgatePontos_PontosNecessarios", "\"PontosNecessarios\" > 0");
                });

            migrationBuilder.CreateTable(
                name: "SaldoEstoque",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EstoqueId = table.Column<long>(type: "bigint", nullable: false),
                    ItemInventarioId = table.Column<long>(type: "bigint", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeReservada = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaldoEstoque", x => x.Id);
                    table.CheckConstraint("CK_SaldoEstoque_Quantidade", "\"Quantidade\" >= 0");
                    table.CheckConstraint("CK_SaldoEstoque_QuantidadeReservada", "\"QuantidadeReservada\" >= 0 AND \"QuantidadeReservada\" <= \"Quantidade\"");
                    table.ForeignKey(
                        name: "FK_SaldoEstoque_Estoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaldoEstoque_ItemInventario_ItemInventarioId",
                        column: x => x.ItemInventarioId,
                        principalTable: "ItemInventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    SenhaHash = table.Column<string>(type: "text", nullable: false),
                    PerfilId = table.Column<long>(type: "bigint", nullable: false),
                    UnidadeId = table.Column<long>(type: "bigint", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<long>(type: "bigint", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Usuario_CriadoPor",
                        column: x => x.CriadoPor,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditoria_UsuarioId",
                table: "Auditoria",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cardapio_CriadoPor",
                table: "Cardapio",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Cardapio_UnidadeId",
                table: "Cardapio",
                column: "UnidadeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardapioItem_CardapioId_ProdutoId",
                table: "CardapioItem",
                columns: new[] { "CardapioId", "ProdutoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardapioItem_CriadoPor",
                table: "CardapioItem",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_CardapioItem_ProdutoId",
                table: "CardapioItem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consentimento_CriadoPor",
                table: "Consentimento",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Consentimento_UsuarioId",
                table: "Consentimento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_CriadoPor",
                table: "Estoque",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_UnidadeId",
                table: "Estoque",
                column: "UnidadeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemInventario_CriadoPor",
                table: "ItemInventario",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_CriadoPor",
                table: "Pagamento",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_PedidoId",
                table: "Pagamento",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CriadoPor",
                table: "Pedido",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UnidadeId",
                table: "Pedido",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_CriadoPor",
                table: "PedidoItem",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId_ProdutoId",
                table: "PedidoItem",
                columns: new[] { "PedidoId", "ProdutoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_ProdutoId",
                table: "PedidoItem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosCliente_ClienteId",
                table: "PontosCliente",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PontosCliente_CriadoPor",
                table: "PontosCliente",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_PontosHistorico_CriadoPor",
                table: "PontosHistorico",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_PontosHistorico_PedidoId",
                table: "PontosHistorico",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosHistorico_PontosClienteId",
                table: "PontosHistorico",
                column: "PontosClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosHistorico_RegraResgateId",
                table: "PontosHistorico",
                column: "RegraResgateId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CriadoPor",
                table: "Produto",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoItemInventario_CriadoPor",
                table: "ProdutoItemInventario",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoItemInventario_ItemInventarioId",
                table: "ProdutoItemInventario",
                column: "ItemInventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoItemInventario_ProdutoId_ItemInventarioId",
                table: "ProdutoItemInventario",
                columns: new[] { "ProdutoId", "ItemInventarioId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receita_CriadoPor",
                table: "Receita",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_ProdutoId",
                table: "Receita",
                column: "ProdutoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaItem_CriadoPor",
                table: "ReceitaItem",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaItem_ItemInventarioId_ReceitaId",
                table: "ReceitaItem",
                columns: new[] { "ItemInventarioId", "ReceitaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaItem_ReceitaId",
                table: "ReceitaItem",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegraResgatePontos_CriadoPor",
                table: "RegraResgatePontos",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_SaldoEstoque_CriadoPor",
                table: "SaldoEstoque",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_SaldoEstoque_EstoqueId",
                table: "SaldoEstoque",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_SaldoEstoque_ItemInventarioId_EstoqueId",
                table: "SaldoEstoque",
                columns: new[] { "ItemInventarioId", "EstoqueId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_CriadoPor",
                table: "Unidade",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CriadoPor",
                table: "Usuario",
                column: "CriadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UnidadeId",
                table: "Usuario",
                column: "UnidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditoria_Usuario_UsuarioId",
                table: "Auditoria",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cardapio_Unidade_UnidadeId",
                table: "Cardapio",
                column: "UnidadeId",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cardapio_Usuario_CriadoPor",
                table: "Cardapio",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CardapioItem_Produto_ProdutoId",
                table: "CardapioItem",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CardapioItem_Usuario_CriadoPor",
                table: "CardapioItem",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consentimento_Usuario_CriadoPor",
                table: "Consentimento",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consentimento_Usuario_UsuarioId",
                table: "Consentimento",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Unidade_UnidadeId",
                table: "Estoque",
                column: "UnidadeId",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Usuario_CriadoPor",
                table: "Estoque",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInventario_Usuario_CriadoPor",
                table: "ItemInventario",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_Pedido_PedidoId",
                table: "Pagamento",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_Usuario_CriadoPor",
                table: "Pagamento",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Unidade_UnidadeId",
                table: "Pedido",
                column: "UnidadeId",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuario_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuario_CriadoPor",
                table: "Pedido",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Produto_ProdutoId",
                table: "PedidoItem",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Usuario_CriadoPor",
                table: "PedidoItem",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosCliente_Usuario_ClienteId",
                table: "PontosCliente",
                column: "ClienteId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosCliente_Usuario_CriadoPor",
                table: "PontosCliente",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosHistorico_RegraResgatePontos_RegraResgateId",
                table: "PontosHistorico",
                column: "RegraResgateId",
                principalTable: "RegraResgatePontos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosHistorico_Usuario_CriadoPor",
                table: "PontosHistorico",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Usuario_CriadoPor",
                table: "Produto",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoItemInventario_Usuario_CriadoPor",
                table: "ProdutoItemInventario",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receita_Usuario_CriadoPor",
                table: "Receita",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaItem_Usuario_CriadoPor",
                table: "ReceitaItem",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegraResgatePontos_Usuario_CriadoPor",
                table: "RegraResgatePontos",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaldoEstoque_Usuario_CriadoPor",
                table: "SaldoEstoque",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidade_Usuario_CriadoPor",
                table: "Unidade",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unidade_Usuario_CriadoPor",
                table: "Unidade");

            migrationBuilder.DropTable(
                name: "Auditoria");

            migrationBuilder.DropTable(
                name: "CardapioItem");

            migrationBuilder.DropTable(
                name: "Consentimento");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropTable(
                name: "PontosHistorico");

            migrationBuilder.DropTable(
                name: "ProdutoItemInventario");

            migrationBuilder.DropTable(
                name: "ReceitaItem");

            migrationBuilder.DropTable(
                name: "SaldoEstoque");

            migrationBuilder.DropTable(
                name: "Cardapio");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "PontosCliente");

            migrationBuilder.DropTable(
                name: "RegraResgatePontos");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "ItemInventario");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Unidade");
        }
    }
}
