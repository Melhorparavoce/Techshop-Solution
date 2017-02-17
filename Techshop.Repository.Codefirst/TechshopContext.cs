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
        public DbSet<Marketplace> Marketplace { get; set; }   
        public DbSet<Logerro> Logerro { get; set; }  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            #region Relacionamento Pedidos Protheus

            modelBuilder.Entity<ItemPedidoProtheus>()
                       .HasRequired<PedidoProtheus>(s => s.PedidoProtheus) 
                       .WithMany(s => s.ItemPedidoProtheus)
                       .HasForeignKey(s => s.CodigoPedido);   


            #endregion

            #region Relacionamento Pedidos Skyhub

            modelBuilder.Entity<ItemPedidos>()
                       .HasRequired<Pedido>(s => s.Pedidos)  
                       .WithMany(s => s.ItensPedidos)  
                       .HasForeignKey(s => s.CodigoPedido);


            #endregion

            #region Configurações        
            modelBuilder.Entity<Pedido>().ToTable("Pedidos");

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("nvarchar"));

            modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(200));

            modelBuilder.Entity<Funcionalidades>().
           HasMany(c => c.Usuarios).
           WithMany(p => p.FuncionalidadesUsuario).
           Map(
               m =>
               {
                   m.MapLeftKey("CodigoFuncionalidade");
                   m.MapRightKey("CodigoUsuario");
                   m.ToTable("FuncionalidadeUsuario");
               });

            #endregion
        }
    }
}
