using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;

namespace Techshop.Repository
{
    public class ItemPedidoRep
    {
        TechshopEntities1 context = new TechshopEntities1();

        public void incluir(OrderItem domain)
        {
            TEC_ITEM_PEDIDO obj = new TEC_ITEM_PEDIDO();

            obj.COD_ID = domain.id;
            obj.COD_ID_PRODUTO = domain.product_id;
            obj.COD_PEDIDO = domain.CodigoPedido;
            obj.DSC_PRECO_ESPECIAL = Convert.ToDecimal(domain.special_price);
            obj.DSC_PRECO_ORIGINAL = Convert.ToDecimal(domain.original_price); 
            obj.DSC_PRODUTO = domain.name;
            obj.DSC_QUANTIDADE = Convert.ToDecimal(domain.qty);
            obj.IND_ATIVO = 1;
                                        
            context.TEC_ITEM_PEDIDO.Add(obj);
            context.SaveChanges();  
           
        }             

    }
}
