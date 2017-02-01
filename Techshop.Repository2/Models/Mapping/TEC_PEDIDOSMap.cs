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
           
            this.Property(t => t.CodigoPedido).HasColumnName("COD_PEDIDO");
            this.Property(t => t.DescricaoCanal).HasColumnName("DSC_CANAL");
            this.Property(t => t.CodigoCanal).HasColumnName("COD_CANAL");
            this.Property(t => t.DataEstimadaEntrega).HasColumnName("DTA_ESTIMADA_ENTREGA");
            this.Property(t => t.DescricaoInterface).HasColumnName("DSC_INTERECE");
            this.Property(t => t.DataLocalizadoDesde).HasColumnName("DTA_LOCALIZADO_DESDE");
            this.Property(t => t.DescricaoStatusSincronizacao).HasColumnName("DSC_STATUS_SINCRONIZACAO");
            this.Property(t => t.DescricaoValorCompra).HasColumnName("DSC_VALOR_COMPRA");
            this.Property(t => t.DescricaoMetodoCompra).HasColumnName("DSC_METODO_COMPR");
            this.Property(t => t.DataAtualizacao).HasColumnName("DTA_ATUALIZACAO");
            this.Property(t => t.DescricaoTotalPedido).HasColumnName("DSC_TOTAL_PEDIDO");
            this.Property(t => t.DescricaoCustoEntrega).HasColumnName("DSC_CUSTO_ENTREGA");
            this.Property(t => t.DescricaoMetodoEntrega).HasColumnName("DSC_METODO_ENTREGA");
            this.Property(t => t.IndImportado).HasColumnName("IND_IMPORTADO");
            this.Property(t => t.CodigoVendedor).HasColumnName("COD_VENDEDOR");
            this.Property(t => t.IndicadorAtivo).HasColumnName("IND_ATIVO");
            this.Property(t => t.DataSincronizacao).HasColumnName("DTA_SINCRONIZACAO");
        }
    }
}
