using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using Model.CodeFirst.Models;

namespace Techshop.Repositoy.CodeFirst
{
    public class ItemPedidoRep : RepositorioGenerico<ItemPedido>
    {
        private TechshopContext context;   

        public ItemPedidoRep()
        {

            context = new TechshopContext();

        }
   
    }
}
