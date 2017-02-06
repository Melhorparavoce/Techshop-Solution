using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using System.Data.SqlClient;
using Techshop.Model;

namespace Techshop.Repositoy.CodeFirst
{
    public class PedidosProtheusRep : RepositorioGenerico<PedidoProtheus>
    {
        #region Propriedades
        private TechshopContext context; 

        public PedidosProtheusRep()
        {     
            context = new TechshopContext();
        }
        #endregion


       

    }   

}
