using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using System.Data.SqlClient;
using Techshop.Model;

namespace Techshop.Repositoy.CodeFirst
{
    public class SubCategoriasRep : RepositorioGenerico<SubCategoria>
    {
        #region  Propriedades
        private TechshopContext context;
        public SubCategoriasRep()
        {
            context = new TechshopContext();
        }

        #endregion

    }
}
