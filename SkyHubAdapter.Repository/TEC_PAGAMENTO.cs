//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tecsshcop.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class TEC_PAGAMENTO
    {
        public int COD_PAGAMENTO { get; set; }
        public Nullable<int> COD_PEDIDO { get; set; }
        public string DSC_METODO { get; set; }
        public string DSC_DETALHES { get; set; }
        public Nullable<int> DSC_QUANT_PARCELAS { get; set; }
        public Nullable<decimal> DSC_VALOR { get; set; }
        public Nullable<int> IND_ATIVO { get; set; }
    
        public virtual TEC_PEDIDOS TEC_PEDIDOS { get; set; }
        public virtual TEC_PEDIDOS TEC_PEDIDOS1 { get; set; }
        public virtual TEC_PEDIDOS TEC_PEDIDOS2 { get; set; }
        public virtual TEC_PEDIDOS TEC_PEDIDOS3 { get; set; }
        public virtual TEC_PEDIDOS TEC_PEDIDOS4 { get; set; }
    }
}
