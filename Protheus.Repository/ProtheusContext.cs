using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Techshop.Model;
using Protheus.Repository.Mapping;

namespace Protheus.Repository
{
    public  class ProtheusContext : DbContext
    {

        #region Contrutores
        static ProtheusContext()
        {
            Database.SetInitializer<ProtheusContext>(null);
          }

        public ProtheusContext()
            : base("Name=ProtheusEntities")
        {
        }
        #endregion

        #region Propriedades
                

        #endregion

        public DbSet<Vendedor> VendedorNovo { get; set; }

        #region Métodos
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            modelBuilder.Configurations.Add(new VendedorMap()); 

        }    
        #endregion
    }
}
