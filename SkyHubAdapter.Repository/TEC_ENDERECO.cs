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
    
    public partial class TEC_ENDERECO
    {
        public int COD_ENDERECO { get; set; }
        public Nullable<int> COD_PEDIDO { get; set; }
        public string DSC_NOME { get; set; }
        public string DSC_RUA { get; set; }
        public string DSC_DETALHES { get; set; }
        public string DSC_BAIRRO { get; set; }
        public string DSC_CIDADE { get; set; }
        public string DSC_REGIAO { get; set; }
        public string DSC_PAIS { get; set; }
        public string DSC_CEP { get; set; }
        public Nullable<int> IND_ATIVO { get; set; }
        public Nullable<int> IND_TIPO_ENDERECO { get; set; }
        public string DSC_TIPO_ENDERECO { get; set; }
    
        public virtual TEC_PEDIDOS TEC_PEDIDOS { get; set; }
        public virtual TEC_PEDIDOS TEC_PEDIDOS1 { get; set; }
        public virtual TEC_PEDIDOS TEC_PEDIDOS2 { get; set; }
        public virtual TEC_PEDIDOS TEC_PEDIDOS3 { get; set; }
        public virtual TEC_PEDIDOS TEC_PEDIDOS4 { get; set; }
        public virtual TEC_PEDIDOS TEC_PEDIDOS5 { get; set; }
    }
}
