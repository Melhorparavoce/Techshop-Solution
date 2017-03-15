using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Techshop.Model
{
    public class Romaneio
    {
        public Romaneio()
        {

            }


        [Key]
        [Column(Order =0)]
        public int CodigoRomaneio { get; set; }

        public DateTime DataFechamento { get; set; }  
      
        public int? CodigoPedidoProtheus { get; set; }

        public int StatusRomaneio { get; set; }

        public string DescricaoStatus { get; set; }

        public int CodigoGrupo { get; set; }



    }
}
