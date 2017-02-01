using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.CodeFirst.Models.Mapping
{
    public class TEC_ITEM_PEDIDOMap : EntityTypeConfiguration<ItemPedido>
    {
        public TEC_ITEM_PEDIDOMap()
        {
            // Primary Key
            this.HasKey(t => t.CodigoItemPedido);

            // Properties
            this.Property(t => t.CodigoId)
                .IsFixedLength()
                .HasMaxLength(100);
        

            this.Property(t => t.DescricaoProduto)
                .IsRequired()
                .HasMaxLength(800);

            // Table & Column Mappings
            this.ToTable("TEC_ITEM_PEDIDO");
            this.Property(t => t.CodigoItemPedido).HasColumnName("COD_ITEM_PEDIDO");
            this.Property(t => t.CodigoPedido).HasColumnName("COD_PEDIDO");
            this.Property(t => t.CodigoId).HasColumnName("COD_ID");
            this.Property(t => t.DescricaoProduto).HasColumnName("DSC_PRODUTO");
            this.Property(t => t.DescricaoQuantidade).HasColumnName("DSC_QUANTIDADE");
            this.Property(t => t.DescricaoPrecoOriginal).HasColumnName("DSC_PRECO_ORIGINAL");
            this.Property(t => t.DescricaoPrecoEspecial).HasColumnName("DSC_PRECO_ESPECIAL");
            this.Property(t => t.IncadorAtivo).HasColumnName("IND_ATIVO");

            

        }
    }
}
