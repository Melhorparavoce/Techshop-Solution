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

            this.ToTable("VW_PRODUTO_VENDEDOR_ECOMMERCE");
            this.Property(t => t.CodigoProduto).HasColumnName("Produto");
            this.Property(t => t.VendedorB2W).HasColumnName("Vendedor_b2w");
            this.Property(t => t.VendedorCNOVA).HasColumnName("vendedor_cnova");
            this.Property(t => t.VendedorTechshop).HasColumnName("vendedor_techshop");

        }

    }
}
