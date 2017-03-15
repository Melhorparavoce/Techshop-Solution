
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techshop.Model
{
    public  class ItemPedidoProtheus
    {
        [Key]
        [Column(Order = 1)]
        public int CodigoItemPedido { get; set; }

        public int CodigoPedidoProtheus { get; set; } 

        [StringLength(40)]
        [Column(TypeName = "char")]
        public string SkuProduto { get; set; }

        [StringLength(20)]
        [Column(TypeName = "char")]
        public string Quantidade { get; set; }

        [StringLength(20)]
        [Column(TypeName = "char")]
        public string Preco { get; set; }
                              
       public virtual PedidoProtheus PedidoProtheus { get; set; }
    }
}
