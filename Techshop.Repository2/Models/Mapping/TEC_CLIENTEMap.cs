using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.CodeFirst.Models.Mapping
{
    public class TEC_CLIENTEMap : EntityTypeConfiguration<Cliente>
    {
        public TEC_CLIENTEMap()
        {
            // Primary Key
            this.HasKey(t => t.CodigoCliente);
               
            // Table & Column Mappings
            this.ToTable("TEC_CLIENTE");
           
            this.Property(t => t.CodigoCliente).HasColumnName("COD_CLIENTE");
            this.Property(t => t.CodigoPedido).HasColumnName("COD_PEDIDO");
            this.Property(t => t.DataNascimento).HasColumnName("DTA_NASCIMENTO");
            this.Property(t => t.DescricaoCliente).HasColumnName("DSC_CLIENTE");
            this.Property(t => t.DescricaoCPF).HasColumnName("DSC_CPF");
            this.Property(t => t.DescricaoEmail).HasColumnName("DSC_EMAIL");
            this.Property(t => t.DescricaoGenero).HasColumnName("DSC_GENERO");
            this.Property(t => t.DescricaoTelefone1).HasColumnName("DSC_TELEFONE1");
            this.Property(t => t.DescricaoTelefone1).HasColumnName("DSC_TELEFONE2");
            this.Property(t => t.DescricaoTelefone1).HasColumnName("DSC_TELEFONE3");
            this.Property(t => t.DescricaoTelefone1).HasColumnName("DSC_TELEFONE4");
            this.Property(t => t.DataNascimento2).HasColumnName("DTA_NASCIMENTO2");

        }
    }
}
