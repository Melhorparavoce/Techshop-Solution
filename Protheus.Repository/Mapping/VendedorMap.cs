using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Techshop.Model;
namespace Protheus.Repository.Mapping
{
    public class VendedorMap: EntityTypeConfiguration<Vendedor>
    {
        public VendedorMap() {

            this.ToTable("VendedorNovo");
            this.Property(t => t.CodigoVedendor).HasColumnName("CodigoVendedor");
            this.Property(t => t.DescricaoVendedor).HasColumnName("DescricaoVendedor");

        }

    }
}
