using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Techshop.Model
{
   public class Marketplace
    {
        [Key]
        [Column(Order = 1)]
        public int CodigoMarketplace { get; set; }
     
        [StringLength(100)]
        public string Parceiro { get; set; }

        [StringLength(100)]
        public string DescricaoMarketplace { get; set; }  



    }
}
