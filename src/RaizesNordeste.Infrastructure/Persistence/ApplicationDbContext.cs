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
            //relacionamentos 1 - N
            //HasMany define a coleção do lado 1 da relação 1:N; WithOne define a referência unica no lado N
            //HasForeignKey define qual propriedade da entidade dependente (lado N) será utilizada como chave estrangeira

            modelBuilder.Entity<Pedido>().HasMany(pedido => pedido.Itens).WithOne(item => item.Pedido).HasForeignKey(item => item.PedidoId);
            modelBuilder.Entity<Pedido>().HasMany(pedido => pedido.Pagamentos).WithOne(pagamento => pagamento.Pedido).HasForeignKey(pagamento => pagamento.PedidoId);
            modelBuilder.Entity<Perfil>().HasMany(perfil => perfil.Usuarios).WithOne(usuario => usuario.Perfil).HasForeignKey(usuario => usuario.PerfilId);
            modelBuilder.Entity<Unidade>().HasMany(unidade => unidade.Usuarios).WithOne(usuario => usuario.Unidade).HasForeignKey(usuario => usuario.UnidadeId);
            modelBuilder.Entity<Unidade>().HasMany(unidade => unidade.Pedidos).WithOne(pedido => pedido.Unidade).HasForeignKey(pedido => pedido.UnidadeId);
            modelBuilder.Entity<Cardapio>().HasMany(cardapio => cardapio.Itens).WithOne(item => item.Cardapio).HasForeignKey(item => item.CardapioId);
            modelBuilder.Entity<Produto>().HasMany(produto => produto.CardapiosItens).WithOne(item => item.Produto).HasForeignKey(item => item.ProdutoId);
            modelBuilder.Entity<Produto>().HasMany(produto => produto.PedidosItens).WithOne(item => item.Produto).HasForeignKey(item => item.ProdutoId);
            modelBuilder.Entity<Estoque>().HasMany(estoque => estoque.Saldos).WithOne(saldo => saldo.Estoque).HasForeignKey(saldo => saldo.EstoqueId);
            modelBuilder.Entity<ItemInventario>().HasMany(item => item.SaldosEstoque).WithOne(saldo => saldo.ItemInventario).HasForeignKey(saldo => saldo.ItemInventarioId);
            modelBuilder.Entity<Receita>().HasMany(receita => receita.Itens).WithOne(item => item.Receita).HasForeignKey(item => item.ReceitaId);
            modelBuilder.Entity<ItemInventario>().HasMany(item => item.ReceitasItens).WithOne(receitaItem => receitaItem.ItemInventario).HasForeignKey(receitaItem => receitaItem.ItemInventarioId);
            modelBuilder.Entity<Produto>().HasMany(produto => produto.ItensInventario).WithOne(item => item.Produto).HasForeignKey(item => item.ProdutoId);
            modelBuilder.Entity<ItemInventario>().HasMany(item => item.ProdutosItens).WithOne(produtoItem => produtoItem.ItemInventario).HasForeignKey(produtoItem => produtoItem.ItemInventarioId);
            modelBuilder.Entity<PontosCliente>().HasMany(pontos => pontos.Historicos).WithOne(historico => historico.PontosCliente).HasForeignKey(historico => historico.PontosClienteId);
            modelBuilder.Entity<RegraResgatePontos>().HasMany(regra => regra.Historicos).WithOne(historico => historico.RegraResgatePontos).HasForeignKey(historico => historico.RegraResgateId);
            modelBuilder.Entity<Usuario>().HasMany(usuario => usuario.Consentimentos).WithOne(consentimento => consentimento.Usuario).HasForeignKey(consentimento => consentimento.UsuarioId);
            modelBuilder.Entity<Usuario>().HasMany(usuario => usuario.PontosClientes).WithOne(pontos => pontos.Cliente).HasForeignKey(pontos => pontos.ClienteId);
            modelBuilder.Entity<Usuario>().HasMany(usuario => usuario.Auditorias).WithOne(auditoria => auditoria.Usuario).HasForeignKey(auditoria => auditoria.UsuarioId);

            //relacionamentos 1 - 1
            modelBuilder.Entity<Unidade>().HasOne(unidade => unidade.Cardapio).WithOne(cardapio => cardapio.Unidade).HasForeignKey<Cardapio>(cardapio => cardapio.UnidadeId);
            modelBuilder.Entity<Unidade>().HasOne(unidade => unidade.Estoque).WithOne(estoque => estoque.Unidade).HasForeignKey<Estoque>(estoque => estoque.UnidadeId);
            modelBuilder.Entity<Produto>().HasOne(produto => produto.Receita).WithOne(receita => receita.Produto).HasForeignKey<Receita>(receita =>  receita.ProdutoId);

            //usuario
            modelBuilder.Entity<Usuario>().HasMany(usuario => usuario.Pedidos).WithOne(pedido => pedido.Cliente).HasForeignKey(pedido => pedido.ClienteId);
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

        }
    }
}