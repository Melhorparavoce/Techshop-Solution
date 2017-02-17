using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

             
namespace Techshop.Model
{
    public  class PedidoProtheus
    {
        public PedidoProtheus()
        {
            ItemPedidoProtheus = new HashSet<ItemPedidoProtheus>();        
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

        [StringLength(50)]
        [Column(TypeName = "char")]
        public string CodigoTabelaPrecos { get; set; }  
                            
        [StringLength(100)]
        [Column(TypeName = "char")]
        public string CodigoVendendor { get; set; }

        [StringLength(150)]
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
 
        [StringLength(250)]
        public string DescricaoBairro { get; set; }

        [StringLength(200)]
        public string DescricaoCep { get; set; }

        [StringLength(500)]
        public string DescricaoCidade { get; set; }

        [StringLength(400)]
        public string DescricaoDetalhes { get; set; }

        [StringLength(250)]
        public string DescricaoNome { get; set; }

        [StringLength(150)]
        public string DescricaoPais { get; set; }

        [StringLength(250)]
        public string DescricaoRegiao { get; set; }

        [StringLength(450)]
        public string DescricaoRua { get; set; }

      
        [StringLength(200)]
        public string DescricaoCanal { get; set; }

        public string Parceiro { get; set; }

        public int CodigoPedidoSkyhub { get; set; }

        [StringLength(400)]
        public string Remetente { get; set; }

        [StringLength(400)]
        public string RemetenteCnpj { get; set; }

        [StringLength(100)]
        public string RemetenteIe { get; set; }

        [StringLength(400)]
        public string RemetenteEndereco { get; set; }

        [StringLength(200)]
        public string RemetenteBairro { get; set; }

        [StringLength(20)]
        public string RemetenteCep { get; set; }
     
        [StringLength(20)]
        public string RemetenteTelefone { get; set; }

        [StringLength(20)]
        public string Volumes { get; set; }

        [StringLength(20)]
        public string PesoReal { get; set; }

        [StringLength(20)]
        public string Especie { get; set; }

        [StringLength(20)]
        public string Conteudo { get; set; }

        [StringLength(20)]
        public string NumeroPedidoProtheus { get; set; }

        [StringLength(44)]
        public string Danfe { get; set; }

        [StringLength(40)]
        public string NumeroNotaFiscal { get; set; }

        [StringLength(20)]
        public string SerieNotaFiscal { get; set; }

        [StringLength(20)]
        public string ValorDeclaradoNota { get; set; }

        [StringLength(20)]
        public string ModalidadeTransporte { get; set; }

        [StringLength(40)]
        public string CodigoColeta { get; set; }

        [StringLength(40)]
        public string CodigoRastreio { get; set; }

        [StringLength(100)]
        public string Transportadora { get; set; }  

        public string MensagemErro { get; set; }

        public string MensagemErroDetalhada { get; set; }

        [StringLength(10)]
        public string StatusImportacao { get; set; }

        /// <summary>
        /// 0- Pedido Novo - Skyhub
        /// 1- Importado Protheus
        /// 2- Erro Importação Protheus
        /// 3- Pedido Faturado
        /// 4- Pedido Enviado Transportadora
        /// 5- Pedido Entregue
        /// 6- Pedido Cancelado        
        /// </summary>
        public int StatusPedido { get; set; }
        public virtual ICollection<ItemPedidoProtheus> ItemPedidoProtheus { get; set; }

    }
}
