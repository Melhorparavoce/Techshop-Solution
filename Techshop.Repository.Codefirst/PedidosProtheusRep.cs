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


        #region Métodos
        public int CriarPedido(PedidoProtheus entidade)
        {
            context.PedidoProtheus.Add(entidade);  
            context.SaveChanges();
            return entidade.CodigoPedido;

        }

        public void ExcluirTodos()
        {
            var rows = from o in context.PedidoProtheus
                       select o;

            foreach (var row in rows)
            {
                context.PedidoProtheus.Remove(row);
            }
            context.SaveChanges();

        }

        #endregion


    }   

}
