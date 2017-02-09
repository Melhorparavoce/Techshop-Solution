using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Techshop.Model
{
   public class Logerro
    {
        [Key]
        [Column(Order = 1)]
        public int CodigoLog { get; set; }

        public string DescricaoOperacao { get; set; }

        public string DescricaoErro { get; set; }

        [MaxLength, Column(TypeName = "ntext")]   
        public string DescricaoExcecao { get; set; }  

        public DateTime DataGeracao { get; set; }

    }
}
