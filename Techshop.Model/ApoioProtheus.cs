using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Techshop.Model
{
   public class ApoioProtheus
    {
        [Key]
        [Column(Order = 1)]
        public int CodigoApoio { get; set; }
     
        [StringLength(100)]
        public string Campo { get; set; }

        [StringLength(50)]
        public string Valor { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }



    }
}
