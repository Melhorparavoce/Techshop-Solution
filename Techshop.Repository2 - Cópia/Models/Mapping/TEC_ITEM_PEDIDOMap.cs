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
            this.Property(t => t.CodigoItemPedido).HasColumnName("CodigoItemPedido");
            this.Property(t => t.CodigoPedido).HasColumnName("CodigoPedido");
            this.Property(t => t.CodigoId).HasColumnName("CodigoId");
            this.Property(t => t.DescricaoProduto).HasColumnName("DescricaoProduto");
            this.Property(t => t.DescricaoQuantidade).HasColumnName("DescricaoQuantidade");
            this.Property(t => t.DescricaoPrecoOriginal).HasColumnName("DescricaoPrecoOriginal");
            this.Property(t => t.DescricaoPrecoEspecial).HasColumnName("DescricaoPrecoEspecial");
            this.Property(t => t.IncadorAtivo).HasColumnName("IncadorAtivo");

            

        }
    }
}
