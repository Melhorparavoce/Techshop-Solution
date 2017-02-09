using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using System.Data.SqlClient;
using Techshop.Model;

namespace Techshop.Repositoy.CodeFirst
{
    public class LogerroRep : RepositorioGenerico<Logerro>
    {
        #region  Propriedades
        private TechshopContext context;
        public LogerroRep()
        {
            context = new TechshopContext();
        }

        #endregion

    }
}
