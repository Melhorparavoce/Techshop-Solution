using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Model.CodeFirst.Models.Mapping;

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

      
        public DbSet<ItemPedido> TEC_ITEM_PEDIDO { get; set; }
        public DbSet<Pedido> TEC_PEDIDOS { get; set; }
        public DbSet<Cliente> TEC_CLIENTE { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pedido>().MapToStoredProcedures();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("nvarchar"));

            modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(200));
                      
                             
            modelBuilder.Configurations.Add(new TEC_ITEM_PEDIDOMap());
            modelBuilder.Configurations.Add(new TEC_PEDIDOSMap());
            modelBuilder.Configurations.Add(new TEC_CLIENTEMap());
            
        }
    }
}
