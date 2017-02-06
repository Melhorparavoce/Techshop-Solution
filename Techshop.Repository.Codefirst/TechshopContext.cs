using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Techshop.Model;

namespace Techshop.Repositoy.CodeFirst
{
    public class TechshopContext : DbContext
    {
        static TechshopContext()
        {
            Database.SetInitializer<TechshopContext>(null);
            //var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public TechshopContext()
            : base("Name=TechshopContext")
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProtheus> PedidoProtheus { get; set; }
        public DbSet<ApoioProtheus> ApoioProtheus { get; set; }
        public DbSet<ItemPedidoProtheus> ItemPedidoProtheus { get; set; }
        public DbSet<ItemPedidos> ItemsPedido { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            /* modelBuilder.Entity<Pedido>()
             .HasRequired(u => u.CodigoPedido)
             .WithRequiredPrincipal();*/

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("nvarchar"));

            modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(200));


        }
    }
}
