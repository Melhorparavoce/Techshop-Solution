using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Model.CodeFirst.Models
{
    public  class TechshopContext : DbContext
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
                         
        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<PedidoProtheus> PedidoProtheus{ get; set; } 
        public DbSet<ApoioProtheus> ApoioProtheus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pedido>().MapToStoredProcedures();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("nvarchar"));

            modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(200));                        
                             

        }
    }
}
