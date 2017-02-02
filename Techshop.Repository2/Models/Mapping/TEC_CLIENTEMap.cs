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
           
            this.Property(t => t.CodigoCliente).HasColumnName("CodigoCliente");
            this.Property(t => t.CodigoPedido).HasColumnName("CodigoPedido");
            this.Property(t => t.DataNascimento).HasColumnName("DataNascimento");
            this.Property(t => t.DescricaoCliente).HasColumnName("DescricaoCliente");
            this.Property(t => t.DescricaoCPF).HasColumnName("DescricaoCpf");
            this.Property(t => t.DescricaoEmail).HasColumnName("DescricaoEmail");
            this.Property(t => t.DescricaoGenero).HasColumnName("DescricaoGenero");
            this.Property(t => t.DescricaoTelefone1).HasColumnName("DescricaoTelefone1");
            this.Property(t => t.DescricaoTelefone2).HasColumnName("DescricaoTelefone2");
            this.Property(t => t.DescricaoTelefone3).HasColumnName("DescricaoTelefone3");
            this.Property(t => t.DescricaoTelefone4).HasColumnName("DescricaoTelefone4");
           

        }
    }
}
