using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using Model.CodeFirst.Models;

namespace Techshop.Repositoy.CodeFirst
{
    public class ItemPedidosProtheusRep : RepositorioGenerico<ItemPedidoProtheus>
    {

         private TechshopContext context;   

        public ItemPedidosProtheusRep()
        {

            context = new TechshopContext();  
        }

      
    }
}
