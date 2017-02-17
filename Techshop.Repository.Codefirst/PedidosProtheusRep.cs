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

        public List<PedidoProtheus> ListarCodigo(int CodigoPedido)         {

            return Listar(where => (where.CodigoPedido == CodigoPedido)).ToList();
        }      

        public List<PedidoProtheus> Listar(int StatusPedido,string Transportadora)
        {

            return Listar(where => (where.StatusPedido == StatusPedido)&& (where.Transportadora.Contains(Transportadora))).ToList();
        }

        public  List<PedidoProtheus> Listar(int StatusPedido)
        {
              
            return Listar(where=>(where.StatusPedido == StatusPedido)).ToList();
        }    

        public void AtualizaStatus(string Danfe, int StatusPedido)
        {
            PedidoProtheus entidade = (from p in context.PedidoProtheus.Where(p => p.Danfe.Contains(Danfe)) select p).FirstOrDefault();
            entidade.StatusPedido = StatusPedido;
            context.SaveChanges();

        }

        public void AtualizaStatus(int CodigoPedido, int StatusPedido)
        {
            TechshopContext context = new TechshopContext();
            PedidoProtheus entidade = (from p in context.PedidoProtheus.Where(p => p.CodigoPedido== CodigoPedido) select p).FirstOrDefault();
            entidade.StatusPedido = StatusPedido;
            context.SaveChanges();
        }

        #endregion       

    }   

}
