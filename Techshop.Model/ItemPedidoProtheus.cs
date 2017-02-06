
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Techshop.Model
{
    public  class ItemPedidoProtheus
    {
        public ItemPedidoProtheus()
        {
                    
        }

        [Key]
        [Column(Order = 1)]
        public int CodigoItemPedido { get; set; }


        [StringLength(40)]
        [Column(TypeName = "char")]
        public string SkuProduto { get; set; }

        [StringLength(20)]
        [Column(TypeName = "char")]
        public string Quantidade { get; set; }

        [StringLength(20)]
        [Column(TypeName = "char")]
        public string Preco { get; set; }
                              

    }
}
