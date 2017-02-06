using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Model;
namespace Techshop.Repositoy.CodeFirst
{
    public class MarketplaceRep : RepositorioGenerico<Marketplace>
    {

         private TechshopContext context;   

        public MarketplaceRep()          {

            context = new TechshopContext();  
        }

        public List<Marketplace> Listar(string DescricaoCanal)
        {
            return Listar(where => where.DescricaoMarketplace.Contains(DescricaoCanal)).ToList();

        }                                                   
       

    }
}
