using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.EntityClient;


namespace Model.CodeFirst.Models
{
    public  class PedidoProtheus
    {
        public PedidoProtheus()
        {
                    
        }

        [Key]
        [Column(Order = 1)]
        public int CodigoPedido { get; set; }


        [StringLength(20)]
        [Column(TypeName = "char")]
        public string TipoPedido { get; set; }

        [StringLength(20)]
        [Column(TypeName = "char")]
        public string TipoFrete { get; set; }

        [StringLength(20)]
        [Column(TypeName = "char")]
        public string CodigoTransportadora { get; set; }

        [StringLength(20)]
        [Column(TypeName = "char")]
        public string CodigoTabelaPrecos { get; set; }

        [StringLength(20)]
        [Column(TypeName = "char")]
        public string CodicaoPagamento { get; set; }

        [StringLength(20)]
        [Column(TypeName = "char")]
        public string FormaPagamento { get; set; }

        [StringLength(20)]
        [Column(TypeName = "char")]
        public string CodigoVendendor { get; set; }

        [StringLength(20)]
        [Column(TypeName = "char")]
        public string NumeroEntregaSkyhub { get; set; } 
          
        public string DescricaoCliente { get; set; }
        [StringLength(250)]

        public string DescricaoEmail { get; set; }
        [StringLength(30)]

        public string DescricaoGenero { get; set; }
        [StringLength(50)]

        public string DescricaoCPF { get; set; }
        [StringLength(50)]

        public string DescricaoTelefone1 { get; set; }
        [StringLength(50)]

        public string DescricaoTelefone2 { get; set; }
        [StringLength(50)]

        public string DescricaoTelefone3 { get; set; }
        [StringLength(50)]

        public string DescricaoTelefone4 { get; set; }
         
        public DateTime DataNascimento { get; set; }  
             
        public string MensagemErro { get; set; }      

        [StringLength(20)]
        [Column(TypeName = "text")]
        public string MensagemErroDetalhada { get; set; }

        [StringLength(10)]
        public string StatusImportacao { get; set; }

    }
}
