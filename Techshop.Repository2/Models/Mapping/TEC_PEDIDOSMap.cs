using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.CodeFirst.Models.Mapping
{
    public class TEC_PEDIDOSMap : EntityTypeConfiguration<Pedido>
    {
        public TEC_PEDIDOSMap()
        {
            // Primary Key
            this.HasKey(t => t.CodigoPedido);

            // Properties
            this.Property(t => t.DescricaoCanal)
                .HasMaxLength(150);

            this.Property(t => t.CodigoCanal)
                .HasMaxLength(150);

            /*this.Property(t => t.DSC_STATUS_SINCRONIZACAO)
                .IsFixedLength()
                .HasMaxLength(10); */

            this.Property(t => t.DescricaoMetodoCompra)
                .HasMaxLength(150);

            this.Property(t => t.DescricaoMetodoEntrega)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("TEC_PEDIDOS");
           
            this.Property(t => t.CodigoPedido).HasColumnName("CodigoPedido");
            this.Property(t => t.DescricaoCanal).HasColumnName("DescricaoCanal");          
            this.Property(t => t.CodigoCanal).HasColumnName("CodigoCanal");
            this.Property(t => t.DataEstimadaEntrega).HasColumnName("DataEstimadaEntrega");
            this.Property(t => t.DescricaoInterface).HasColumnName("DescricaoInterface");
            this.Property(t => t.DataLocalizadoDesde).HasColumnName("DataLocalizadoDesde");
            this.Property(t => t.DescricaoStatusSincronizacao).HasColumnName("DescricaoStatusSincronizacao");
            this.Property(t => t.DescricaoValorCompra).HasColumnName("DescricaoMetodoCompra");
            this.Property(t => t.DescricaoMetodoCompra).HasColumnName("DescricaoMetodoCompra");
            this.Property(t => t.DataAtualizacao).HasColumnName("DataAtualizacao");
            this.Property(t => t.DescricaoTotalPedido).HasColumnName("DescricaoTotalPedido");
            this.Property(t => t.DescricaoCustoEntrega).HasColumnName("DescricaoCustoEntrega");
            this.Property(t => t.DescricaoMetodoEntrega).HasColumnName("DescricaoMetodoEntrega");
            this.Property(t => t.IndImportado).HasColumnName("IndImportado");
            this.Property(t => t.CodigoVendedor).HasColumnName("CodigoVendedor");
            this.Property(t => t.IndicadorAtivo).HasColumnName("IndicadorAtivo");
            this.Property(t => t.DataSincronizacao).HasColumnName("DataSincronizacao");
        }
    }
}
