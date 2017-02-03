using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CodeFirst.Models
{
    public  class ItemPedidos
    {

        [Key]
        [Column(Order = 1)]
        public int CodigoItemPedido { get; set; }
        public int CodigoPedido { get; set; }
        public string CodigoId { get; set; }
        public string DescricaoProduto { get; set; }
        public Nullable<decimal> DescricaoQuantidade { get; set; }
        public Nullable<decimal> DescricaoPrecoOriginal { get; set; }
        public Nullable<decimal> DescricaoPrecoEspecial { get; set; }
        public Nullable<int> IncadorAtivo { get; set; }
 
    }
}
