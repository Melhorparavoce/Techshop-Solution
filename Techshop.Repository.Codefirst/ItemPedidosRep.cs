using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Model;
namespace Techshop.Repositoy.CodeFirst
{
    public class ItemPedidoRep : RepositorioGenerico<ItemPedidos>
    {

         private TechshopContext context;   

        public ItemPedidoRep()          {

            context = new TechshopContext();  
        }

        public List<ItemPedidos> Listar(int CodigoPedido)
        {
            return Listar(where => where.CodigoPedido == CodigoPedido).ToList();

        }                                                   
                                                                              
        public void CriarItemPedido(ItemPedidos EntidadeItemPedido)
        {  
            context.ItemsPedido.Add(EntidadeItemPedido);
            context.SaveChanges();          
              
        }

    }
}
