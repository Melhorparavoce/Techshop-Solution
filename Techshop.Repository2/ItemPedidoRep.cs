using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using Model.CodeFirst.Models;

namespace Techshop.Repositoy.CodeFirst
{
    public class ItemPedidoRep
    {
        private TechshopContext context;   

        public ItemPedidoRep()
        {

            context = new TechshopContext();

        }

        public void incluir(OrderItem domain)
        {
            ItemPedido obj = new ItemPedido();

            obj.CodigoId = domain.id;
            //obj.COD_ID_PRODUTO = domain.product_id;
            obj.CodigoPedido = domain.CodigoPedido;
            obj.DescricaoPrecoEspecial = Convert.ToDecimal(domain.special_price);
            obj.DescricaoPrecoOriginal = Convert.ToDecimal(domain.original_price); 
            obj.DescricaoProduto = domain.name;
            obj.DescricaoQuantidade = Convert.ToDecimal(domain.qty);
                                                 
            context.ItemPedido.Add(obj);
            context.SaveChanges(); 
           
        }          

    }
}
