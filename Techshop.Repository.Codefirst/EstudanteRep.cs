using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using System.Data.SqlClient;
using Techshop.Model;

namespace Techshop.Repositoy.CodeFirst
{
    public class EstudanteRep : RepositorioGenerico<Professores>
    {
        private TechshopContext context;


        public EstudanteRep()
        {     
            context = new TechshopContext();
        }     


        public void CriarEstudante(Professores EntidadePedido)
        {            
            context.Professores.Add(EntidadePedido);
            context.SaveChanges();

            //return EntidadePedido.CodigoPedido;
            
        }

  
    }
    

}
