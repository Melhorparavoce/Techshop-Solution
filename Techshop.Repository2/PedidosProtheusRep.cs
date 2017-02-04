using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using Model.CodeFirst.Models;
using System.Data.SqlClient;

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
