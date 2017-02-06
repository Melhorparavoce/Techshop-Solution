using System;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Repositoy.CodeFirst;
using Techshop.Model;
using System.Collections.Generic;
using Protheus.Repository;

namespace Techshop.Aplication
{
    public class MarketplaceApp
    {
        #region Propriedades
        private MarketplaceRep objMarketplaceRep;
        public MarketplaceApp()
        {
            objMarketplaceRep = new MarketplaceRep();

        }

        #endregion

        #region Métodos


        public string RetornaParceiro(string DescricaoCanal)
        {
           List<Marketplace> list = objMarketplaceRep.Listar(DescricaoCanal);

            if (list.Count > 0)
            {
                return list[0].Parceiro;

            }  else {

                return "Outros";
            }

        }      

        #endregion

    }

}
