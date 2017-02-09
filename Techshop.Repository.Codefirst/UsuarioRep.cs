using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using System.Data.SqlClient;
using Techshop.Model;

namespace Techshop.Repositoy.CodeFirst
{
    public class UsuarioRep:RepositorioGenerico<Usuario>
    {

        #region Propriedades
        private TechshopContext context;

        public UsuarioRep()
        {           
            context = new TechshopContext();
        }
        #endregion

        #region Métodos



        #endregion

    }
}
