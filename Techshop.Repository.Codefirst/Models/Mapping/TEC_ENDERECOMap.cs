using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.CodeFirst.Models.Mapping
{
    public class TEC_ENDERECOMap : EntityTypeConfiguration<Endereco>
    {
        public TEC_ENDERECOMap()
        {
            // Primary Key
            this.HasKey(t => t.CodigoEndereco);
               
            // Table & Column Mappings
            this.ToTable("TEC_ENDERECO");
           
            this.Property(t => t.CodigoEndereco).HasColumnName("CodigoEndereco");
            this.Property(t => t.CodigoPedido).HasColumnName("CodigoPedido");
            this.Property(t => t.DescricaoBairro).HasColumnName("DescricaoBairro");
            this.Property(t => t.DescricaoCep).HasColumnName("DescricaoCep");
            this.Property(t => t.DescricaoCidade).HasColumnName("DescricaoCidade");
            this.Property(t => t.DescricaoDetalhes).HasColumnName("DescricaoDetalhes");
            this.Property(t => t.DescricaoNome).HasColumnName("DescricaoNome");
            this.Property(t => t.DescricaoPais).HasColumnName("DescricaoPais");
            this.Property(t => t.DescricaoRegiao).HasColumnName("DescricaoRegiao");
            this.Property(t => t.DescricaoRua).HasColumnName("DescricaoRua");
            this.Property(t => t.IndicadorTipoEndereco).HasColumnName("IndicadorTipoEndereco");
           

        }
    }
}
