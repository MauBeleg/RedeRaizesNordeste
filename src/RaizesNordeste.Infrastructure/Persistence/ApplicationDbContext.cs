using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Enums;



// contexto do EF Core que realiza o mapeamento das entidades e o acesso ao banco de dados
namespace RaizesNordeste.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<CardapioItem> CardapioItens { get; set; }
        public DbSet<ItemInventario> ItensInventario { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<SaldoEstoque> SaldosEstoque { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<ReceitaItem> ReceitaItens { get; set; }
        public DbSet<ProdutoItemInventario> ProdutoItensInventario { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<PontosCliente> PontosClientes { get; set; }
        public DbSet<PontosHistorico> PontosHistoricos { get; set; }
        public DbSet<RegraResgatePontos> RegrasResgatePontos { get; set; }
        public DbSet<Consentimento> Consentimentos { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }


        //define os relacionamentos entre as entidades para depois ser utilizadas nas interações com o bd
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //nomes das tabelas
            modelBuilder.Entity<Perfil>().ToTable("Perfil");
            modelBuilder.Entity<Unidade>().ToTable("Unidade");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Cardapio>().ToTable("Cardapio");
            modelBuilder.Entity<CardapioItem>().ToTable("CardapioItem");
            modelBuilder.Entity<ItemInventario>().ToTable("ItemInventario");
            modelBuilder.Entity<Estoque>().ToTable("Estoque");
            modelBuilder.Entity<SaldoEstoque>().ToTable("SaldoEstoque");
            modelBuilder.Entity<Receita>().ToTable("Receita");
            modelBuilder.Entity<ReceitaItem>().ToTable("ReceitaItem");
            modelBuilder.Entity<ProdutoItemInventario>().ToTable("ProdutoItemInventario");
            modelBuilder.Entity<Pedido>().ToTable("Pedido");
            modelBuilder.Entity<PedidoItem>().ToTable("PedidoItem");
            modelBuilder.Entity<Pagamento>().ToTable("Pagamento");
            modelBuilder.Entity<PontosCliente>().ToTable("PontosCliente");
            modelBuilder.Entity<PontosHistorico>().ToTable("PontosHistorico");
            modelBuilder.Entity<RegraResgatePontos>().ToTable("RegraResgatePontos");
            modelBuilder.Entity<Consentimento>().ToTable("Consentimento");
            modelBuilder.Entity<Auditoria>().ToTable("Auditoria");


            //relacionamentos 1 - N
            //HasMany define a coleção do lado 1 da relação 1:N; WithOne define a referência unica no lado N
            //HasForeignKey define qual propriedade da entidade dependente (lado N) será utilizada como chave estrangeira
            modelBuilder.Entity<Pedido>().HasMany(pedido => pedido.Itens).WithOne(item => item.Pedido).HasForeignKey(item => item.PedidoId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Pedido>().HasMany(pedido => pedido.Pagamentos).WithOne(pagamento => pagamento.Pedido).HasForeignKey(pagamento => pagamento.PedidoId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Perfil>().HasMany(perfil => perfil.Usuarios).WithOne(usuario => usuario.Perfil).HasForeignKey(usuario => usuario.PerfilId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Unidade>().HasMany(unidade => unidade.Usuarios).WithOne(usuario => usuario.Unidade).HasForeignKey(usuario => usuario.UnidadeId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Unidade>().HasMany(unidade => unidade.Pedidos).WithOne(pedido => pedido.Unidade).HasForeignKey(pedido => pedido.UnidadeId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Cardapio>().HasMany(cardapio => cardapio.Itens).WithOne(item => item.Cardapio).HasForeignKey(item => item.CardapioId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Produto>().HasMany(produto => produto.CardapiosItens).WithOne(item => item.Produto).HasForeignKey(item => item.ProdutoId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Produto>().HasMany(produto => produto.PedidosItens).WithOne(item => item.Produto).HasForeignKey(item => item.ProdutoId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Estoque>().HasMany(estoque => estoque.Saldos).WithOne(saldo => saldo.Estoque).HasForeignKey(saldo => saldo.EstoqueId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ItemInventario>().HasMany(item => item.SaldosEstoque).WithOne(saldo => saldo.ItemInventario).HasForeignKey(saldo => saldo.ItemInventarioId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Receita>().HasMany(receita => receita.Itens).WithOne(item => item.Receita).HasForeignKey(item => item.ReceitaId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ItemInventario>().HasMany(item => item.ReceitasItens).WithOne(receitaItem => receitaItem.ItemInventario).HasForeignKey(receitaItem => receitaItem.ItemInventarioId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Produto>().HasMany(produto => produto.ItensInventario).WithOne(item => item.Produto).HasForeignKey(item => item.ProdutoId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ItemInventario>().HasMany(item => item.ProdutosItens).WithOne(produtoItem => produtoItem.ItemInventario).HasForeignKey(produtoItem => produtoItem.ItemInventarioId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PontosCliente>().HasMany(pontos => pontos.Historicos).WithOne(historico => historico.PontosCliente).HasForeignKey(historico => historico.PontosClienteId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RegraResgatePontos>().HasMany(regra => regra.Historicos).WithOne(historico => historico.RegraResgatePontos).HasForeignKey(historico => historico.RegraResgateId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Usuario>().HasMany(usuario => usuario.Consentimentos).WithOne(consentimento => consentimento.Usuario).HasForeignKey(consentimento => consentimento.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Usuario>().HasMany(usuario => usuario.PontosClientes).WithOne(pontos => pontos.Cliente).HasForeignKey(pontos => pontos.ClienteId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Usuario>().HasMany(usuario => usuario.Auditorias).WithOne(auditoria => auditoria.Usuario).HasForeignKey(auditoria => auditoria.UsuarioId).OnDelete(DeleteBehavior.Restrict);

            //relacionamentos 1 - 1
            modelBuilder.Entity<Unidade>().HasOne(unidade => unidade.Cardapio).WithOne(cardapio => cardapio.Unidade).HasForeignKey<Cardapio>(cardapio => cardapio.UnidadeId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Unidade>().HasOne(unidade => unidade.Estoque).WithOne(estoque => estoque.Unidade).HasForeignKey<Estoque>(estoque => estoque.UnidadeId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Produto>().HasOne(produto => produto.Receita).WithOne(receita => receita.Produto).HasForeignKey<Receita>(receita => receita.ProdutoId).OnDelete(DeleteBehavior.Restrict);

            //usuario
            modelBuilder.Entity<Usuario>().HasMany(usuario => usuario.Pedidos).WithOne(pedido => pedido.Cliente).HasForeignKey(pedido => pedido.ClienteId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Pedido>().HasOne(pedido => pedido.UsuarioCriador).WithMany().HasForeignKey(pedido => pedido.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            // relacionamento usuario - usuario (campo CriadoPor)
            modelBuilder.Entity<Usuario>().HasOne(usuario => usuario.UsuarioCriador).WithMany().HasForeignKey(usuario => usuario.CriadoPor).OnDelete(DeleteBehavior.Restrict);

            //relacionamento do sistema de pontos com o pedido
            modelBuilder.Entity<PontosHistorico>().HasOne(pontosHistorico => pontosHistorico.Pedido).WithMany().HasForeignKey(pontosHistorico => pontosHistorico.PedidoId).OnDelete(DeleteBehavior.Restrict);

            //relacionamentos de Auditoria (coluna CriadoPor)
            modelBuilder.Entity<Produto>().HasOne(produto => produto.UsuarioCriador).WithMany().HasForeignKey(produto => produto.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Cardapio>().HasOne(cardapio => cardapio.UsuarioCriador).WithMany().HasForeignKey(cardapio => cardapio.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CardapioItem>().HasOne(item => item.UsuarioCriador).WithMany().HasForeignKey(item => item.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Consentimento>().HasOne(consentimento => consentimento.UsuarioCriador).WithMany().HasForeignKey(consentimento => consentimento.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Estoque>().HasOne(estoque => estoque.UsuarioCriador).WithMany().HasForeignKey(estoque => estoque.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ItemInventario>().HasOne(item => item.UsuarioCriador).WithMany().HasForeignKey(item => item.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Pagamento>().HasOne(pagamento => pagamento.UsuarioCriador).WithMany().HasForeignKey(pagamento => pagamento.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PedidoItem>().HasOne(item => item.UsuarioCriador).WithMany().HasForeignKey(item => item.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PontosCliente>().HasOne(pontos => pontos.UsuarioCriador).WithMany().HasForeignKey(pontos => pontos.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PontosHistorico>().HasOne(historico => historico.UsuarioCriador).WithMany().HasForeignKey(historico => historico.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProdutoItemInventario>().HasOne(item => item.UsuarioCriador).WithMany().HasForeignKey(item => item.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Receita>().HasOne(receita => receita.UsuarioCriador).WithMany().HasForeignKey(receita => receita.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ReceitaItem>().HasOne(item => item.UsuarioCriador).WithMany().HasForeignKey(item => item.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RegraResgatePontos>().HasOne(regra => regra.UsuarioCriador).WithMany().HasForeignKey(regra => regra.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SaldoEstoque>().HasOne(saldo => saldo.UsuarioCriador).WithMany().HasForeignKey(saldo => saldo.CriadoPor).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Unidade>().HasOne(unidade => unidade.UsuarioCriador).WithMany().HasForeignKey(unidade => unidade.CriadoPor).OnDelete(DeleteBehavior.Restrict);

            //precisao de valores monetarios
            modelBuilder.Entity<Produto>().Property(produto => produto.ValorUnitario).HasPrecision(12, 2);
            modelBuilder.Entity<Pagamento>().Property(pagamento => pagamento.Valor).HasPrecision(12, 2);
            modelBuilder.Entity<Pedido>().Property(pedido => pedido.Subtotal).HasPrecision(12, 2);
            modelBuilder.Entity<Pedido>().Property(pedido => pedido.Desconto).HasPrecision(12, 2);
            modelBuilder.Entity<Pedido>().Property(pedido => pedido.ValorTotal).HasPrecision(12, 2);
            modelBuilder.Entity<PedidoItem>().Property(pedidoItem => pedidoItem.ValorUnitario).HasPrecision(12, 2);
            modelBuilder.Entity<PedidoItem>().Property(pedidoItem => pedidoItem.ValorTotal).HasPrecision(12, 2);


            //conversao dos enums
            modelBuilder.Entity<Pagamento>().Property(pagamento => pagamento.Status).HasConversion<string>();
            modelBuilder.Entity<Pedido>().Property(pedido => pedido.CanalPedido).HasConversion<string>();
            modelBuilder.Entity<Pedido>().Property(pedido => pedido.Status).HasConversion<string>();
            modelBuilder.Entity<Produto>().Property(produto => produto.TipoProduto).HasConversion<string>();
            modelBuilder.Entity<PontosHistorico>().Property(pontosHistorico => pontosHistorico.TipoMovimentacao).HasConversion<string>();
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Setor).HasConversion<string>();


            //configuracao dos dados pessoais do usuario
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Cpf).HasMaxLength(11);
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.DataNascimento).HasColumnType("date");



            //definicao dos indices

            //indices unicos
            modelBuilder.Entity<Usuario>().HasIndex(usuario => usuario.Email).IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(usuario => usuario.Cpf).IsUnique();
            modelBuilder.Entity<PontosCliente>().HasIndex(pontosCliente => pontosCliente.ClienteId).IsUnique();


            //indices compostos
            modelBuilder.Entity<CardapioItem>().HasIndex(item => new { item.CardapioId, item.ProdutoId }).IsUnique();
            modelBuilder.Entity<SaldoEstoque>().HasIndex(saldo => new { saldo.ItemInventarioId, saldo.EstoqueId }).IsUnique();
            modelBuilder.Entity<ReceitaItem>().HasIndex(item => new { item.ItemInventarioId, item.ReceitaId }).IsUnique();
            modelBuilder.Entity<ProdutoItemInventario>().HasIndex(produtoItemInventario => new { produtoItemInventario.ProdutoId, produtoItemInventario.ItemInventarioId }).IsUnique();
            modelBuilder.Entity<PedidoItem>().HasIndex(item => new { item.PedidoId, item.ProdutoId }).IsUnique();


            //check constraints simples
            modelBuilder.Entity<Pagamento>().ToTable(t => t.HasCheckConstraint("CK_Pagamento_Valor", "\"Valor\" >= 0"));
            modelBuilder.Entity<Pedido>().ToTable(t => t.HasCheckConstraint("CK_Pedido_Subtotal", "\"Subtotal\" >= 0"));
            modelBuilder.Entity<Pedido>().ToTable(t => t.HasCheckConstraint("CK_Pedido_Desconto", "\"Desconto\" >= 0"));
            modelBuilder.Entity<Pedido>().ToTable(t => t.HasCheckConstraint("CK_Pedido_ValorTotal", "\"ValorTotal\" >= 0"));
            modelBuilder.Entity<PedidoItem>().ToTable(t => t.HasCheckConstraint("CK_PedidoItem_Quantidade", "\"Quantidade\" > 0"));
            modelBuilder.Entity<PedidoItem>().ToTable(t => t.HasCheckConstraint("CK_PedidoItem_ValorUnitario", "\"ValorUnitario\" > 0"));
            modelBuilder.Entity<PedidoItem>().ToTable(t => t.HasCheckConstraint("CK_PedidoItem_ValorTotal", "\"ValorTotal\" > 0"));
            modelBuilder.Entity<PontosHistorico>().ToTable(t => t.HasCheckConstraint("CK_PontosHistorico_Quantidade", "\"Quantidade\" > 0"));
            modelBuilder.Entity<Produto>().ToTable(t => t.HasCheckConstraint("CK_Produto_ValorUnitario", "\"ValorUnitario\" > 0"));
            modelBuilder.Entity<ProdutoItemInventario>().ToTable(t => t.HasCheckConstraint("CK_ProdutoItemInventario_QuantidadeConsumo", "\"QuantidadeConsumo\" > 0"));
            modelBuilder.Entity<ReceitaItem>().ToTable(t => t.HasCheckConstraint("CK_ReceitaItem_Quantidade", "\"Quantidade\" > 0"));
            modelBuilder.Entity<RegraResgatePontos>().ToTable(t => t.HasCheckConstraint("CK_RegraResgatePontos_PontosNecessarios", "\"PontosNecessarios\" > 0"));
            modelBuilder.Entity<RegraResgatePontos>().ToTable(t => t.HasCheckConstraint("CK_RegraResgatePontos_PercentualDesconto", "\"PercentualDesconto\" > 0 AND \"PercentualDesconto\" <= 100"));
            modelBuilder.Entity<SaldoEstoque>().ToTable(t => t.HasCheckConstraint("CK_SaldoEstoque_Quantidade", "\"Quantidade\" >= 0"));
            modelBuilder.Entity<SaldoEstoque>().ToTable(t => t.HasCheckConstraint("CK_SaldoEstoque_QuantidadeReservada", "\"QuantidadeReservada\" >= 0 AND \"QuantidadeReservada\" <= \"Quantidade\""));

            //inserção de registros fundamentais nas tabelas

            //Perfis
            modelBuilder.Entity<Perfil>().HasData(new Perfil { Id = 1, Nome = "Sistema", Descricao = "Perfil utilizado para operações automáticas dentro do sistema" },
                                                  new Perfil { Id = 2, Nome = "Administrador", Descricao = "Perfil com acesso admnistrativo do sistema" },
                                                  new Perfil { Id = 3, Nome = "Funcionário", Descricao = "Perfil utilizado pelos funcionários de uma unidade dentro do sistema" },
                                                  new Perfil { Id = 4, Nome = "Cliente", Descricao = "Perfil utilizado pelos clientes" });

            //Unidades
            modelBuilder.Entity<Unidade>().HasData(new Unidade { Id = 1, Nome = "Raízes do Nordeste - Recife", Ativo = true, CriadoPor = null, DataCriacao = new DateTime(2026, 10, 1, 12, 0, 0, DateTimeKind.Utc) },
                                                   new Unidade { Id = 2, Nome = "Raízes do Nordeste - Salvador", Ativo = true, CriadoPor = null, DataCriacao = new DateTime(2026, 10, 1, 12, 0, 0, DateTimeKind.Utc) },
                                                   new Unidade { Id = 3, Nome = "Raízes do Nordeste - Fortaleza", Ativo = true, CriadoPor = null, DataCriacao = new DateTime(2026, 10, 1, 12, 0, 0, DateTimeKind.Utc) }
            );

            //Estoque
            modelBuilder.Entity<Estoque>().HasData(new Estoque { Id = 1, UnidadeId = 1, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 30, 0, DateTimeKind.Utc) },
                                                   new Estoque { Id = 2, UnidadeId = 2, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 30, 0, DateTimeKind.Utc) },
                                                   new Estoque { Id = 3, UnidadeId = 3, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 30, 0, DateTimeKind.Utc) });


            //Usuarios
            modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 1, Nome = "Sistema", Email = "sistema@raizes.local", SenhaHash = "AQAAAAIAAYagAAAAEHfOA8Co7qyl63HqVLQ1cqCF8AtGeHVgOF4cq9NQv2eghCoPEJgZLGu85y8EQ4aiow==", PerfilId = 1, UnidadeId = null, Ativo = true, CriadoPor = null, DataCriacao = new DateTime(2026, 10, 1, 12, 0, 0, DateTimeKind.Utc), Setor = null },
                                                    new Usuario { Id = 2, Nome = "Administrador", Email = "admin@raizes.local", SenhaHash = "AQAAAAIAAYagAAAAEJj8/fMqEpLneFB1tluL56efVKodwkkR5hglovNbLUfM9fR14RfYolR+fAe2kIwTnA==", PerfilId = 2, UnidadeId = null, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 5, 0, DateTimeKind.Utc), Setor = null },

                                                    //Funcionarios - Recife
                                                    new Usuario { Id = 3, Nome = "Rafael Oliveira", Email = "rafael.oliveira@raizes.local", SenhaHash = "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==", Cpf = "00000000001", DataNascimento = new DateTime(1992, 4, 15), PerfilId = 3, UnidadeId = 1, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 10, 0, DateTimeKind.Utc), Setor = SetorFuncionario.Atendimento },
                                                    new Usuario { Id = 4, Nome = "Juliana Santos", Email = "juliana.santos@raizes.local", SenhaHash = "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==", Cpf = "00000000002", DataNascimento = new DateTime(1995, 8, 22), PerfilId = 3, UnidadeId = 1, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 11, 0, DateTimeKind.Utc), Setor = SetorFuncionario.Cozinha },

                                                    //Funcionarios - Salvador
                                                    new Usuario { Id = 5, Nome = "Lucas Almeida", Email = "lucas.almeida@raizes.local", SenhaHash = "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==", Cpf = "00000000003", DataNascimento = new DateTime(1990, 11, 3), PerfilId = 3, UnidadeId = 2, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 12, 0, DateTimeKind.Utc), Setor = SetorFuncionario.Atendimento },
                                                    new Usuario { Id = 6, Nome = "Camila Ferreira", Email = "camila.ferreira@raizes.local", SenhaHash = "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==", Cpf = "00000000004", DataNascimento = new DateTime(1994, 2, 18), PerfilId = 3, UnidadeId = 2, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 13, 0, DateTimeKind.Utc), Setor = SetorFuncionario.Cozinha },

                                                    //Funcionarios - Fortaleza
                                                    new Usuario { Id = 7, Nome = "Bruno Carvalho", Email = "bruno.carvalho@raizes.local", SenhaHash = "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==", Cpf = "00000000005", DataNascimento = new DateTime(1989, 7, 9), PerfilId = 3, UnidadeId = 3, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 14, 0, DateTimeKind.Utc), Setor = SetorFuncionario.Atendimento },
                                                    new Usuario { Id = 8, Nome = "Mariana Costa", Email = "mariana.costa@raizes.local", SenhaHash = "AQAAAAIAAYagAAAAEG4QNxGphe8Gbmlt2j7ZCt6/OoiWOL1RYnsmZXcowGlpvq+JgZ88xxrstrX0EJyeGw==", Cpf = "00000000006", DataNascimento = new DateTime(1987, 12, 12), PerfilId = 3, UnidadeId = 3, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 15, 0, DateTimeKind.Utc), Setor = SetorFuncionario.Gerencia },

                                                    //Clientes
                                                    new Usuario { Id = 9, Nome = "Ana Souza", Email = "ana.souza@demo.local", SenhaHash = "AQAAAAIAAYagAAAAEG0asrp6NVUc19UatFt4ocTMUHJYjQNMTOIzZnAeE4SV747XQMOA95vsrG4SRUt0tg==", Cpf = "00000000007", DataNascimento = new DateTime(1998, 5, 20), PerfilId = 4, UnidadeId = null, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 20, 0, DateTimeKind.Utc), Setor = null },
                                                    new Usuario { Id = 10, Nome = "Carlos Lima", Email = "carlos.lima@demo.local", SenhaHash = "AQAAAAIAAYagAAAAEG0asrp6NVUc19UatFt4ocTMUHJYjQNMTOIzZnAeE4SV747XQMOA95vsrG4SRUt0tg==", Cpf = "00000000008", DataNascimento = new DateTime(1986, 9, 14), PerfilId = 4, UnidadeId = null, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 21, 0, DateTimeKind.Utc), Setor = null },
                                                    new Usuario { Id = 11, Nome = "Fernanda Rocha", Email = "fernanda.rocha@demo.local", SenhaHash = "AQAAAAIAAYagAAAAEG0asrp6NVUc19UatFt4ocTMUHJYjQNMTOIzZnAeE4SV747XQMOA95vsrG4SRUt0tg==", Cpf = "00000000009", DataNascimento = new DateTime(1993, 3, 27), PerfilId = 4, UnidadeId = null, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 22, 0, DateTimeKind.Utc), Setor = null },
                                                    new Usuario { Id = 12, Nome = "Pedro Martins", Email = "pedro.martins@demo.local", SenhaHash = "AQAAAAIAAYagAAAAEG0asrp6NVUc19UatFt4ocTMUHJYjQNMTOIzZnAeE4SV747XQMOA95vsrG4SRUt0tg==", Cpf = "00000000010", DataNascimento = new DateTime(1996, 6, 8), PerfilId = 4, UnidadeId = null, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 23, 0, DateTimeKind.Utc), Setor = null });
            //Produtos
            modelBuilder.Entity<Produto>().HasData(new Produto { Id = 1, Nome = "Baião de Dois", Descricao = "Baião de dois tradicional", ValorUnitario = 24.90m, TipoProduto = TipoProduto.Preparado, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) },
                                                   new Produto { Id = 2, Nome = "Carne de Sol com Macaxeira", Descricao = "Carne de sol acompanhada de macaxeira", ValorUnitario = 34.90m, TipoProduto = TipoProduto.Preparado, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) },
                                                   new Produto { Id = 3, Nome = "Cuscuz Nordestino", Descricao = "Cuscuz tradicional nordestino", ValorUnitario = 16.90m, TipoProduto = TipoProduto.Preparado, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) },
                                                   new Produto { Id = 4, Nome = "Água Mineral", Descricao = "Água mineral sem gás", ValorUnitario = 5.00m, TipoProduto = TipoProduto.Unitario, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) },
                                                   new Produto { Id = 5, Nome = "Escondidinho de Carne de Sol", Descricao = "Escondidinho de macaxeira com carne de sol e queijo coalho", ValorUnitario = 29.90m, TipoProduto = TipoProduto.Preparado, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) },
                                                   new Produto { Id = 6, Nome = "Acarajé", Descricao = "Acarajé tradicional com camarão", ValorUnitario = 18.90m, TipoProduto = TipoProduto.Preparado, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) },
                                                   new Produto { Id = 7, Nome = "Moqueca Baiana", Descricao = "Moqueca de peixe com camarão e leite de coco", ValorUnitario = 39.90m, TipoProduto = TipoProduto.Preparado, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) },
                                                   new Produto { Id = 8, Nome = "Tapioca de Queijo Coalho", Descricao = "Tapioca recheada com queijo coalho", ValorUnitario = 15.90m, TipoProduto = TipoProduto.Preparado, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) },
                                                   new Produto { Id = 9, Nome = "Cartola", Descricao = "Sobremesa de banana com queijo coalho, açúcar e canela", ValorUnitario = 14.90m, TipoProduto = TipoProduto.Preparado, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) },
                                                   new Produto { Id = 10, Nome = "Refrigerante Lata", Descricao = "Refrigerante em lata", ValorUnitario = 7.00m, TipoProduto = TipoProduto.Unitario, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) },
                                                   new Produto { Id = 11, Nome = "Suco de Cajá", Descricao = "Suco de cajá pronto para consumo", ValorUnitario = 8.00m, TipoProduto = TipoProduto.Unitario, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) },
                                                   new Produto { Id = 12, Nome = "Suco de Umbu", Descricao = "Suco de umbu pronto para consumo", ValorUnitario = 8.00m, TipoProduto = TipoProduto.Unitario, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 45, 0, DateTimeKind.Utc) });


            //ItemInventario - itens armazenados no estoque
            modelBuilder.Entity<ItemInventario>().HasData(new ItemInventario { Id = 1, Nome = "Arroz", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 2, Nome = "Feijão", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 3, Nome = "Carne de Sol", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 4, Nome = "Macaxeira", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 5, Nome = "Flocão de Milho", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 6, Nome = "Água Mineral", UnidadeMedida = "un", Tipo = "Produto", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 7, Nome = "Queijo Coalho", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 8, Nome = "Massa de Mandioca", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 9, Nome = "Camarão", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 10, Nome = "Feijão-Fradinho", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 11, Nome = "Peixe", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 12, Nome = "Leite de Coco", UnidadeMedida = "ml", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 13, Nome = "Purê de Macaxeira", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 14, Nome = "Banana", UnidadeMedida = "un", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 15, Nome = "Açúcar", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 16, Nome = "Canela", UnidadeMedida = "g", Tipo = "Ingrediente", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 17, Nome = "Refrigerante Lata", UnidadeMedida = "un", Tipo = "Produto", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 18, Nome = "Suco de Cajá", UnidadeMedida = "un", Tipo = "Produto", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) },
                                                          new ItemInventario { Id = 19, Nome = "Suco de Umbu", UnidadeMedida = "un", Tipo = "Produto", Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 35, 0, DateTimeKind.Utc) });

            //SaldoEstoque - Recife
            modelBuilder.Entity<SaldoEstoque>().HasData(new SaldoEstoque { Id = 1, EstoqueId = 1, ItemInventarioId = 1, Quantidade = 20000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 2, EstoqueId = 1, ItemInventarioId = 2, Quantidade = 15000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 3, EstoqueId = 1, ItemInventarioId = 3, Quantidade = 12000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 4, EstoqueId = 1, ItemInventarioId = 4, Quantidade = 15000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 5, EstoqueId = 1, ItemInventarioId = 5, Quantidade = 10000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 6, EstoqueId = 1, ItemInventarioId = 6, Quantidade = 60, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 7, EstoqueId = 1, ItemInventarioId = 7, Quantidade = 8000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 8, EstoqueId = 1, ItemInventarioId = 8, Quantidade = 8000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 9, EstoqueId = 1, ItemInventarioId = 9, Quantidade = 6000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 10, EstoqueId = 1, ItemInventarioId = 10, Quantidade = 5000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 11, EstoqueId = 1, ItemInventarioId = 11, Quantidade = 6000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 12, EstoqueId = 1, ItemInventarioId = 12, Quantidade = 8000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 13, EstoqueId = 1, ItemInventarioId = 13, Quantidade = 8000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 14, EstoqueId = 1, ItemInventarioId = 14, Quantidade = 50, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 15, EstoqueId = 1, ItemInventarioId = 15, Quantidade = 5000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 16, EstoqueId = 1, ItemInventarioId = 16, Quantidade = 1000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 17, EstoqueId = 1, ItemInventarioId = 17, Quantidade = 50, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 18, EstoqueId = 1, ItemInventarioId = 18, Quantidade = 40, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 19, EstoqueId = 1, ItemInventarioId = 19, Quantidade = 30, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },

                                                        //Salvador
                                                        new SaldoEstoque { Id = 20, EstoqueId = 2, ItemInventarioId = 1, Quantidade = 15000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 21, EstoqueId = 2, ItemInventarioId = 2, Quantidade = 10000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 22, EstoqueId = 2, ItemInventarioId = 3, Quantidade = 6000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 23, EstoqueId = 2, ItemInventarioId = 4, Quantidade = 8000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 24, EstoqueId = 2, ItemInventarioId = 5, Quantidade = 8000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 25, EstoqueId = 2, ItemInventarioId = 6, Quantidade = 50, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 26, EstoqueId = 2, ItemInventarioId = 7, Quantidade = 6000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 27, EstoqueId = 2, ItemInventarioId = 8, Quantidade = 5000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 28, EstoqueId = 2, ItemInventarioId = 9, Quantidade = 10000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 29, EstoqueId = 2, ItemInventarioId = 10, Quantidade = 12000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 30, EstoqueId = 2, ItemInventarioId = 11, Quantidade = 12000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 31, EstoqueId = 2, ItemInventarioId = 12, Quantidade = 10000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 32, EstoqueId = 2, ItemInventarioId = 13, Quantidade = 5000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 33, EstoqueId = 2, ItemInventarioId = 14, Quantidade = 40, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 34, EstoqueId = 2, ItemInventarioId = 15, Quantidade = 4000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 35, EstoqueId = 2, ItemInventarioId = 16, Quantidade = 800, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 36, EstoqueId = 2, ItemInventarioId = 17, Quantidade = 40, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 37, EstoqueId = 2, ItemInventarioId = 18, Quantidade = 30, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 38, EstoqueId = 2, ItemInventarioId = 19, Quantidade = 50, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },

                                                        //Fortaleza
                                                        new SaldoEstoque { Id = 39, EstoqueId = 3, ItemInventarioId = 1, Quantidade = 18000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 40, EstoqueId = 3, ItemInventarioId = 2, Quantidade = 14000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 41, EstoqueId = 3, ItemInventarioId = 3, Quantidade = 15000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 42, EstoqueId = 3, ItemInventarioId = 4, Quantidade = 18000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 43, EstoqueId = 3, ItemInventarioId = 5, Quantidade = 15000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 44, EstoqueId = 3, ItemInventarioId = 6, Quantidade = 50, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 45, EstoqueId = 3, ItemInventarioId = 7, Quantidade = 10000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 46, EstoqueId = 3, ItemInventarioId = 8, Quantidade = 10000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 47, EstoqueId = 3, ItemInventarioId = 9, Quantidade = 5000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 48, EstoqueId = 3, ItemInventarioId = 10, Quantidade = 5000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 49, EstoqueId = 3, ItemInventarioId = 11, Quantidade = 5000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 50, EstoqueId = 3, ItemInventarioId = 12, Quantidade = 5000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 51, EstoqueId = 3, ItemInventarioId = 13, Quantidade = 10000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 52, EstoqueId = 3, ItemInventarioId = 14, Quantidade = 40, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 53, EstoqueId = 3, ItemInventarioId = 15, Quantidade = 4000, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 54, EstoqueId = 3, ItemInventarioId = 16, Quantidade = 800, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 55, EstoqueId = 3, ItemInventarioId = 17, Quantidade = 50, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 56, EstoqueId = 3, ItemInventarioId = 18, Quantidade = 50, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) },
                                                        new SaldoEstoque { Id = 57, EstoqueId = 3, ItemInventarioId = 19, Quantidade = 30, QuantidadeReservada = 0, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 40, 0, DateTimeKind.Utc) });

            //Receitas - somente produtos preparados
            modelBuilder.Entity<Receita>().HasData(new Receita { Id = 1, ProdutoId = 1, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 50, 0, DateTimeKind.Utc) },
                                                   new Receita { Id = 2, ProdutoId = 2, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 50, 0, DateTimeKind.Utc) },
                                                   new Receita { Id = 3, ProdutoId = 3, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 50, 0, DateTimeKind.Utc) },
                                                   new Receita { Id = 4, ProdutoId = 5, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 50, 0, DateTimeKind.Utc) },
                                                   new Receita { Id = 5, ProdutoId = 6, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 50, 0, DateTimeKind.Utc) },
                                                   new Receita { Id = 6, ProdutoId = 7, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 50, 0, DateTimeKind.Utc) },
                                                   new Receita { Id = 7, ProdutoId = 8, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 50, 0, DateTimeKind.Utc) },
                                                   new Receita { Id = 8, ProdutoId = 9, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 50, 0, DateTimeKind.Utc) });


            //ReceitaItem - ingredientes dos produtos preparados
            modelBuilder.Entity<ReceitaItem>().HasData(
                //Baião de Dois
                new ReceitaItem { Id = 1, ReceitaId = 1, ItemInventarioId = 1, Quantidade = 150, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 2, ReceitaId = 1, ItemInventarioId = 2, Quantidade = 100, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 3, ReceitaId = 1, ItemInventarioId = 7, Quantidade = 50, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },

                //Carne de Sol com Macaxeira
                new ReceitaItem { Id = 4, ReceitaId = 2, ItemInventarioId = 3, Quantidade = 200, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 5, ReceitaId = 2, ItemInventarioId = 4, Quantidade = 200, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },

                //Cuscuz Nordestino
                new ReceitaItem { Id = 6, ReceitaId = 3, ItemInventarioId = 5, Quantidade = 150, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 7, ReceitaId = 3, ItemInventarioId = 7, Quantidade = 50, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },

                //Escondidinho de Carne de Sol
                new ReceitaItem { Id = 8, ReceitaId = 4, ItemInventarioId = 13, Quantidade = 200, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 9, ReceitaId = 4, ItemInventarioId = 3, Quantidade = 150, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 10, ReceitaId = 4, ItemInventarioId = 7, Quantidade = 50, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },

                //Acarajé
                new ReceitaItem { Id = 11, ReceitaId = 5, ItemInventarioId = 10, Quantidade = 150, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 12, ReceitaId = 5, ItemInventarioId = 9, Quantidade = 80, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },

                //Moqueca Baiana
                new ReceitaItem { Id = 13, ReceitaId = 6, ItemInventarioId = 11, Quantidade = 200, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 14, ReceitaId = 6, ItemInventarioId = 12, Quantidade = 100, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 15, ReceitaId = 6, ItemInventarioId = 9, Quantidade = 80, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },

                //Tapioca de Queijo Coalho
                new ReceitaItem { Id = 16, ReceitaId = 7, ItemInventarioId = 8, Quantidade = 120, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 17, ReceitaId = 7, ItemInventarioId = 7, Quantidade = 80, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },

                //Cartola
                new ReceitaItem { Id = 18, ReceitaId = 8, ItemInventarioId = 14, Quantidade = 1, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 19, ReceitaId = 8, ItemInventarioId = 7, Quantidade = 80, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 20, ReceitaId = 8, ItemInventarioId = 15, Quantidade = 20, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) },
                new ReceitaItem { Id = 21, ReceitaId = 8, ItemInventarioId = 16, Quantidade = 5, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 12, 55, 0, DateTimeKind.Utc) });


            //ProdutoItemInventario - produtos unitários vinculados diretamente ao estoque
            modelBuilder.Entity<ProdutoItemInventario>().HasData(new ProdutoItemInventario { Id = 1, ProdutoId = 4, ItemInventarioId = 6, QuantidadeConsumo = 1, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 0, 0, DateTimeKind.Utc) },
                                                                 new ProdutoItemInventario { Id = 2, ProdutoId = 10, ItemInventarioId = 17, QuantidadeConsumo = 1, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 0, 0, DateTimeKind.Utc) },
                                                                 new ProdutoItemInventario { Id = 3, ProdutoId = 11, ItemInventarioId = 18, QuantidadeConsumo = 1, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 0, 0, DateTimeKind.Utc) },
                                                                 new ProdutoItemInventario { Id = 4, ProdutoId = 12, ItemInventarioId = 19, QuantidadeConsumo = 1, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 0, 0, DateTimeKind.Utc) });


            //Cardapios
            modelBuilder.Entity<Cardapio>().HasData(new Cardapio { Id = 1, UnidadeId = 1, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 5, 0, DateTimeKind.Utc) },
                                                    new Cardapio { Id = 2, UnidadeId = 2, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 5, 0, DateTimeKind.Utc) },
                                                    new Cardapio { Id = 3, UnidadeId = 3, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 5, 0, DateTimeKind.Utc) });

            //CardapioItem
            modelBuilder.Entity<CardapioItem>().HasData(
                //Recife
                new CardapioItem { Id = 1, CardapioId = 1, ProdutoId = 1, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 2, CardapioId = 1, ProdutoId = 2, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 3, CardapioId = 1, ProdutoId = 3, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 4, CardapioId = 1, ProdutoId = 5, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 5, CardapioId = 1, ProdutoId = 8, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 6, CardapioId = 1, ProdutoId = 9, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 7, CardapioId = 1, ProdutoId = 4, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 8, CardapioId = 1, ProdutoId = 10, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 9, CardapioId = 1, ProdutoId = 11, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },

                //Salvador
                new CardapioItem { Id = 10, CardapioId = 2, ProdutoId = 1, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 11, CardapioId = 2, ProdutoId = 6, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 12, CardapioId = 2, ProdutoId = 7, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 13, CardapioId = 2, ProdutoId = 3, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 14, CardapioId = 2, ProdutoId = 9, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 15, CardapioId = 2, ProdutoId = 4, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 16, CardapioId = 2, ProdutoId = 10, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 17, CardapioId = 2, ProdutoId = 12, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },

                //Fortaleza
                new CardapioItem { Id = 18, CardapioId = 3, ProdutoId = 1, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 19, CardapioId = 3, ProdutoId = 2, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 20, CardapioId = 3, ProdutoId = 3, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 21, CardapioId = 3, ProdutoId = 8, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 22, CardapioId = 3, ProdutoId = 5, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 23, CardapioId = 3, ProdutoId = 4, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 24, CardapioId = 3, ProdutoId = 10, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) },
                new CardapioItem { Id = 25, CardapioId = 3, ProdutoId = 11, Ativo = true, CriadoPor = 1, DataCriacao = new DateTime(2026, 10, 1, 13, 10, 0, DateTimeKind.Utc) }
            );


            //Pedidos historicos
            modelBuilder.Entity<Pedido>().HasData(new Pedido { Id = 1, ClienteId = 9, UnidadeId = 1, CanalPedido = CanalPedido.App, Subtotal = 29.90m, Desconto = 0.00m, ValorTotal = 29.90m, Status = StatusPedido.Entregue, CriadoPor = 9, DataCriacao = new DateTime(2026, 10, 1, 18, 30, 0, DateTimeKind.Utc) },
                                                    new Pedido { Id = 2, ClienteId = 10, UnidadeId = 2, CanalPedido = CanalPedido.Web, Subtotal = 46.90m, Desconto = 0.00m, ValorTotal = 46.90m, Status = StatusPedido.Entregue, CriadoPor = 10, DataCriacao = new DateTime(2026, 10, 2, 19, 10, 0, DateTimeKind.Utc) },
                                                    new Pedido { Id = 3, ClienteId = 11, UnidadeId = 3, CanalPedido = CanalPedido.App, Subtotal = 42.90m, Desconto = 0.00m, ValorTotal = 42.90m, Status = StatusPedido.Pronto, CriadoPor = 11, DataCriacao = new DateTime(2026, 10, 3, 20, 0, 0, DateTimeKind.Utc) },
                                                    new Pedido { Id = 4, ClienteId = 12, UnidadeId = 1, CanalPedido = CanalPedido.Web, Subtotal = 44.80m, Desconto = 0.00m, ValorTotal = 44.80m, Status = StatusPedido.EmPreparo, CriadoPor = 12, DataCriacao = new DateTime(2026, 10, 4, 18, 45, 0, DateTimeKind.Utc) },
                                                    new Pedido { Id = 5, ClienteId = 9, UnidadeId = 2, CanalPedido = CanalPedido.App, Subtotal = 42.80m, Desconto = 0.00m, ValorTotal = 42.80m, Status = StatusPedido.Recebido, CriadoPor = 9, DataCriacao = new DateTime(2026, 10, 5, 19, 20, 0, DateTimeKind.Utc) },
                                                    new Pedido { Id = 6, ClienteId = 10, UnidadeId = 3, CanalPedido = CanalPedido.Web, Subtotal = 23.90m, Desconto = 0.00m, ValorTotal = 23.90m, Status = StatusPedido.AguardandoPagamento, CriadoPor = 10, DataCriacao = new DateTime(2026, 10, 6, 20, 15, 0, DateTimeKind.Utc) });


            //PedidoItem
            modelBuilder.Entity<PedidoItem>().HasData(
                //Pedido 1 - Ana / Recife
                new PedidoItem { Id = 1, PedidoId = 1, ProdutoId = 1, Quantidade = 1, ValorUnitario = 24.90m, ValorTotal = 24.90m, CriadoPor = 9, DataCriacao = new DateTime(2026, 10, 1, 18, 30, 0, DateTimeKind.Utc) },
                new PedidoItem { Id = 2, PedidoId = 1, ProdutoId = 4, Quantidade = 1, ValorUnitario = 5.00m, ValorTotal = 5.00m, CriadoPor = 9, DataCriacao = new DateTime(2026, 10, 1, 18, 30, 0, DateTimeKind.Utc) },

                //Pedido 2 - Carlos / Salvador
                new PedidoItem { Id = 3, PedidoId = 2, ProdutoId = 7, Quantidade = 1, ValorUnitario = 39.90m, ValorTotal = 39.90m, CriadoPor = 10, DataCriacao = new DateTime(2026, 10, 2, 19, 10, 0, DateTimeKind.Utc) },
                new PedidoItem { Id = 4, PedidoId = 2, ProdutoId = 10, Quantidade = 1, ValorUnitario = 7.00m, ValorTotal = 7.00m, CriadoPor = 10, DataCriacao = new DateTime(2026, 10, 2, 19, 10, 0, DateTimeKind.Utc) },

                //Pedido 3 - Fernanda / Fortaleza
                new PedidoItem { Id = 5, PedidoId = 3, ProdutoId = 2, Quantidade = 1, ValorUnitario = 34.90m, ValorTotal = 34.90m, CriadoPor = 11, DataCriacao = new DateTime(2026, 10, 3, 20, 0, 0, DateTimeKind.Utc) },
                new PedidoItem { Id = 6, PedidoId = 3, ProdutoId = 11, Quantidade = 1, ValorUnitario = 8.00m, ValorTotal = 8.00m, CriadoPor = 11, DataCriacao = new DateTime(2026, 10, 3, 20, 0, 0, DateTimeKind.Utc) },

                //Pedido 4 - Pedro / Recife
                new PedidoItem { Id = 7, PedidoId = 4, ProdutoId = 5, Quantidade = 1, ValorUnitario = 29.90m, ValorTotal = 29.90m, CriadoPor = 12, DataCriacao = new DateTime(2026, 10, 4, 18, 45, 0, DateTimeKind.Utc) },
                new PedidoItem { Id = 8, PedidoId = 4, ProdutoId = 9, Quantidade = 1, ValorUnitario = 14.90m, ValorTotal = 14.90m, CriadoPor = 12, DataCriacao = new DateTime(2026, 10, 4, 18, 45, 0, DateTimeKind.Utc) },

                //Pedido 5 - Ana / Salvador
                new PedidoItem { Id = 9, PedidoId = 5, ProdutoId = 6, Quantidade = 2, ValorUnitario = 18.90m, ValorTotal = 37.80m, CriadoPor = 9, DataCriacao = new DateTime(2026, 10, 5, 19, 20, 0, DateTimeKind.Utc) },
                new PedidoItem { Id = 10, PedidoId = 5, ProdutoId = 4, Quantidade = 1, ValorUnitario = 5.00m, ValorTotal = 5.00m, CriadoPor = 9, DataCriacao = new DateTime(2026, 10, 5, 19, 20, 0, DateTimeKind.Utc) },

                //Pedido 6 - Carlos / Fortaleza
                new PedidoItem { Id = 11, PedidoId = 6, ProdutoId = 3, Quantidade = 1, ValorUnitario = 16.90m, ValorTotal = 16.90m, CriadoPor = 10, DataCriacao = new DateTime(2026, 10, 6, 20, 15, 0, DateTimeKind.Utc) },
                new PedidoItem { Id = 12, PedidoId = 6, ProdutoId = 10, Quantidade = 1, ValorUnitario = 7.00m, ValorTotal = 7.00m, CriadoPor = 10, DataCriacao = new DateTime(2026, 10, 6, 20, 15, 0, DateTimeKind.Utc) });


            //Pagamentos historicos
            modelBuilder.Entity<Pagamento>().HasData(new Pagamento { Id = 1, PedidoId = 1, Status = StatusPagamento.Aprovado, FormaPagamento = MetodoPagamento.Pix, Valor = 29.90m, IdentificadorExterno = "MOCK-PAG-0001", CriadoPor = 9, DataCriacao = new DateTime(2026, 10, 1, 18, 32, 0, DateTimeKind.Utc) },
                                                       new Pagamento { Id = 2, PedidoId = 2, Status = StatusPagamento.Aprovado, FormaPagamento = MetodoPagamento.Credito, Valor = 46.90m, IdentificadorExterno = "MOCK-PAG-0002", CriadoPor = 10, DataCriacao = new DateTime(2026, 10, 2, 19, 12, 0, DateTimeKind.Utc) },
                                                       new Pagamento { Id = 3, PedidoId = 3, Status = StatusPagamento.Aprovado, FormaPagamento = MetodoPagamento.Debito, Valor = 42.90m, IdentificadorExterno = "MOCK-PAG-0003", CriadoPor = 11, DataCriacao = new DateTime(2026, 10, 3, 20, 2, 0, DateTimeKind.Utc) },
                                                       new Pagamento { Id = 4, PedidoId = 4, Status = StatusPagamento.Aprovado, FormaPagamento = MetodoPagamento.Pix, Valor = 44.80m, IdentificadorExterno = "MOCK-PAG-0004", CriadoPor = 12, DataCriacao = new DateTime(2026, 10, 4, 18, 47, 0, DateTimeKind.Utc) },
                                                       new Pagamento { Id = 5, PedidoId = 5, Status = StatusPagamento.Aprovado, FormaPagamento = MetodoPagamento.Credito, Valor = 42.80m, IdentificadorExterno = "MOCK-PAG-0005", CriadoPor = 9, DataCriacao = new DateTime(2026, 10, 5, 19, 22, 0, DateTimeKind.Utc) });



            //Consentimentos
            modelBuilder.Entity<Consentimento>().HasData(
                new Consentimento { Id = 1, UsuarioId = 9, TipoConsentimento = "FIDELIZACAO", Aceito = true, CriadoPor = 9, DataCriacao = new DateTime(2026, 10, 1, 18, 0, 0, DateTimeKind.Utc) },
                new Consentimento { Id = 2, UsuarioId = 10, TipoConsentimento = "CAMPANHAS", Aceito = false, CriadoPor = 10, DataCriacao = new DateTime(2026, 10, 2, 18, 30, 0, DateTimeKind.Utc) },
                new Consentimento { Id = 3, UsuarioId = 11, TipoConsentimento = "CAMPANHAS", Aceito = true, CriadoPor = 11, DataCriacao = new DateTime(2026, 10, 3, 19, 20, 0, DateTimeKind.Utc) }
            );


            //Auditorias
            modelBuilder.Entity<Auditoria>().HasData(
                //Pedidos criados
                new Auditoria { Id = 1, UsuarioId = 9, Acao = "PEDIDO_CRIADO", Entidade = "PEDIDO", RegistroId = 1, Detalhes = "Pedido criado pelo cliente.", DataCriacao = new DateTime(2026, 10, 1, 18, 30, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 2, UsuarioId = 10, Acao = "PEDIDO_CRIADO", Entidade = "PEDIDO", RegistroId = 2, Detalhes = "Pedido criado pelo cliente.", DataCriacao = new DateTime(2026, 10, 2, 19, 10, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 3, UsuarioId = 11, Acao = "PEDIDO_CRIADO", Entidade = "PEDIDO", RegistroId = 3, Detalhes = "Pedido criado pelo cliente.", DataCriacao = new DateTime(2026, 10, 3, 20, 0, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 4, UsuarioId = 12, Acao = "PEDIDO_CRIADO", Entidade = "PEDIDO", RegistroId = 4, Detalhes = "Pedido criado pelo cliente.", DataCriacao = new DateTime(2026, 10, 4, 18, 45, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 5, UsuarioId = 9, Acao = "PEDIDO_CRIADO", Entidade = "PEDIDO", RegistroId = 5, Detalhes = "Pedido criado pelo cliente.", DataCriacao = new DateTime(2026, 10, 5, 19, 20, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 6, UsuarioId = 10, Acao = "PEDIDO_CRIADO", Entidade = "PEDIDO", RegistroId = 6, Detalhes = "Pedido criado pelo cliente.", DataCriacao = new DateTime(2026, 10, 6, 20, 15, 0, DateTimeKind.Utc) },

                //Pagamentos processados
                new Auditoria { Id = 7, UsuarioId = 9, Acao = "PAGAMENTO_PROCESSADO", Entidade = "PEDIDO", RegistroId = 1, Detalhes = "Pagamento processado com sucesso.", DataCriacao = new DateTime(2026, 10, 1, 18, 32, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 8, UsuarioId = 10, Acao = "PAGAMENTO_PROCESSADO", Entidade = "PEDIDO", RegistroId = 2, Detalhes = "Pagamento processado com sucesso.", DataCriacao = new DateTime(2026, 10, 2, 19, 12, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 9, UsuarioId = 11, Acao = "PAGAMENTO_PROCESSADO", Entidade = "PEDIDO", RegistroId = 3, Detalhes = "Pagamento processado com sucesso.", DataCriacao = new DateTime(2026, 10, 3, 20, 2, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 10, UsuarioId = 12, Acao = "PAGAMENTO_PROCESSADO", Entidade = "PEDIDO", RegistroId = 4, Detalhes = "Pagamento processado com sucesso.", DataCriacao = new DateTime(2026, 10, 4, 18, 47, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 11, UsuarioId = 9, Acao = "PAGAMENTO_PROCESSADO", Entidade = "PEDIDO", RegistroId = 5, Detalhes = "Pagamento processado com sucesso.", DataCriacao = new DateTime(2026, 10, 5, 19, 22, 0, DateTimeKind.Utc) },

                //Alterações de status realizadas por funcionários
                new Auditoria { Id = 12, UsuarioId = 3, Acao = "STATUS_ALTERADO", Entidade = "PEDIDO", RegistroId = 1, Detalhes = "Status do pedido alterado para Entregue.", DataCriacao = new DateTime(2026, 10, 1, 19, 15, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 13, UsuarioId = 5, Acao = "STATUS_ALTERADO", Entidade = "PEDIDO", RegistroId = 2, Detalhes = "Status do pedido alterado para Entregue.", DataCriacao = new DateTime(2026, 10, 2, 20, 0, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 14, UsuarioId = 7, Acao = "STATUS_ALTERADO", Entidade = "PEDIDO", RegistroId = 3, Detalhes = "Status do pedido alterado para Pronto.", DataCriacao = new DateTime(2026, 10, 3, 20, 40, 0, DateTimeKind.Utc) },
                new Auditoria { Id = 15, UsuarioId = 4, Acao = "STATUS_ALTERADO", Entidade = "PEDIDO", RegistroId = 4, Detalhes = "Status do pedido alterado para EmPreparo.", DataCriacao = new DateTime(2026, 10, 4, 19, 5, 0, DateTimeKind.Utc) }
            );




        }
    }
}