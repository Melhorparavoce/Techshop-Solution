//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Techshop.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class TEC_ITEM_PEDIDO
    {
        public int COD_ITEM_PEDIDO { get; set; }
        public Nullable<int> COD_PEDIDO { get; set; }
        public string COD_ID { get; set; }
        public string COD_ID_PRODUTO { get; set; }
        public string DSC_PRODUTO { get; set; }
        public Nullable<decimal> DSC_QUANTIDADE { get; set; }
        public Nullable<decimal> DSC_PRECO_ORIGINAL { get; set; }
        public Nullable<decimal> DSC_PRECO_ESPECIAL { get; set; }
        public Nullable<int> IND_ATIVO { get; set; }
    
        public virtual TEC_PEDIDOS TEC_PEDIDOS { get; set; }
    }
}
