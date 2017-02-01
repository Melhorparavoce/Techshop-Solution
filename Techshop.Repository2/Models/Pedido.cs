using System;
using System.Collections.Generic;

namespace Model.CodeFirst.Models
{
    public  class Pedido
    {
        public Pedido()
        {
           this.TEC_ITEM_PEDIDO = new List<ItemPedido>();
         
        }
                   
        public int CodigoPedido { get; set; }
        public string DescricaoCanal { get; set; }
        public string CodigoCanal { get; set; }

        public int galoggggg { get; set; }

        public System.DateTime DataEstimadaEntrega { get; set; }
        public Nullable<decimal> DescricaoInterface { get; set; }
        public System.DateTime DataLocalizadoDesde { get; set; }
        public string DescricaoStatusSincronizacao { get; set; }
        public Nullable<decimal> DescricaoValorCompra { get; set; }
        public string DescricaoMetodoCompra { get; set; }
        public Nullable<System.DateTime> DataAtualizacao { get; set; }
        public Nullable<decimal> DescricaoTotalPedido { get; set; }
        public Nullable<decimal> DescricaoCustoEntrega { get; set; }
        public string DescricaoMetodoEntrega { get; set; }
        public Nullable<int> IndImportado { get; set; }
        public Nullable<int> CodigoVendedor { get; set; }
        public int ?IndicadorAtivo { get; set; }       

        public Nullable<System.DateTime> DataSincronizacao { get; set; }
        public virtual ICollection<ItemPedido> TEC_ITEM_PEDIDO { get; set; }
       
       
    }
}
