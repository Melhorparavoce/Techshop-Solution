using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.CodeFirst.Models.Mapping
{
    public class ApoioProtheusMap : EntityTypeConfiguration<ApoioProtheus>
    {
        public ApoioProtheusMap()
        {
            // Primary Key
            this.HasKey(t => t.CodigoApoio);
               
            // Table & Column Mappings
            this.ToTable("TEC_APOIO_PROTHEUS");
           
            this.Property(t => t.CodigoApoio).HasColumnName("CodigoApoio");
            this.Property(t => t.Campo).HasColumnName("Campo");
            this.Property(t => t.Valor).HasColumnName("Valor");
            

        }
    }
}
