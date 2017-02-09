using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techshop.Model
{
    public  class Pedido
    {
        public Pedido()
        {
                    
        }
        [Key]
        [Column(Order = 1)]
        public int CodigoPedido { get; set; }
        public string DescricaoCanal { get; set; }
        public string CodigoSkyhub { get; set; }   
        public System.DateTime DataEstimadaEntrega { get; set; }
        public System.DateTime DataLocalizadoDesde { get; set; }
        public string DescricaoStatusSincronizacao { get; set; }
        public Nullable<decimal> DescricaoValorCompra { get; set; }
        public Nullable<System.DateTime> DataAtualizacao { get; set; }
        public Nullable<decimal> DescricaoTotalPedido { get; set; }
        public Nullable<decimal> DescricaoCustoEntrega { get; set; }
        public Nullable<decimal> DescricaoInteresse { get; set; }
        public string DescricaoMetodoEntrega { get; set; }
       
        /// <summary>
        /// Informações de Cliente
        /// </summary>
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

         /// <summary>
         /// Informações Endereço
         /// </summary>
        [StringLength(250)]
        public string DescricaoBairro { get; set; }

        [StringLength(200)]
        public string DescricaoCep { get; set; }

        [StringLength(300)]
        public string DescricaoCidade { get; set; }

        [StringLength(200)]
        public string DescricaoDetalhes { get; set; }

        [StringLength(250)]
        public string DescricaoNome { get; set; }

        [StringLength(50)]
        public string DescricaoPais { get; set; }

        [StringLength(250)]
        public string DescricaoRegiao { get; set; }

        [StringLength(450)]
        public string DescricaoRua { get; set; }      

        public Nullable<int> IndImportadoProtheus { get; set; }  
             
        public Nullable<System.DateTime> DataSincronizacao { get; set; }

        

        // public IEnumerable<ItemPedido> PedidoDetalhes { get; set; }

    }
}
