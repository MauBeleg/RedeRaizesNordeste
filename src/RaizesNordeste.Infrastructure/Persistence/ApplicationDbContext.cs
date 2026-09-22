using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Domain.Entities;



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



            //definicao dos indices

            //indices unicos
            modelBuilder.Entity<Usuario>().HasIndex(usuario => usuario.Email).IsUnique();
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
            modelBuilder.Entity<Perfil>().HasData(new Perfil { Id = 1 , Nome = "Sistema" ,        Descricao = "Perfil utilizado para operações automáticas dentro do sistema"},
                                                  new Perfil { Id = 2 , Nome = "Administrador" ,  Descricao = "Perfil com acesso admnistrativo do sistema" },
                                                  new Perfil { Id = 3 , Nome = "Funcionário" ,    Descricao = "Perfil utilizado pelos funcionários de uma unidade dentro do sistema" },
                                                  new Perfil { Id = 4 , Nome = "Cliente" ,        Descricao = "Perfil utilizado pelos clientes" });

        }
    }
}