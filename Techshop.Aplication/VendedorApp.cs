using System;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Repositoy.CodeFirst;
using Techshop.Model;  
using System.Collections.Generic;
using Protheus.Repository;

namespace Techshop.Aplication
{
    public class VendedorApp
    {
        #region Propriedades
        private VendedorRep objVendedorRep;
        public VendedorApp()
        {
            objVendedorRep = new VendedorRep();

        }

        #endregion

        #region Métodos
      

        public string RetornaVendedor(string Produto,string Parceiro)
        {
            List<Vendedor> list = objVendedorRep.Consulta(Produto);

            if(Parceiro=="B2W")
            {
                return list[0].VendedorB2W;
            }
            else if (Parceiro == "CNOVA")
            {
                return list[0].VendedorCNOVA;

            }
            else
            {
                return "N Encont";

            }
               
            return "";
                      
        }

        #endregion
       
    }

}
