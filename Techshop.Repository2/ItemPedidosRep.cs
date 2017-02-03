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

        private TechshopContext context = new TechshopContext();
       /* private TechshopContext context;   

        public ItemPedidoRep()          {

            context = new TechshopContext();  
        }      */

        public void CriarItemPedido(ItemPedidos EntidadeItemPedido)          {

            context.ItemsPedido.Add(EntidadeItemPedido);
            context.SaveChanges();              
            //  return context.  
        }

    }
}
