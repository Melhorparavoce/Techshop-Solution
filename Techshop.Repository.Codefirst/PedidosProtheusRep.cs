using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using System.Data.SqlClient;
using Techshop.Model;
using System.Globalization;
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
               return entidade.CodigoPedidoProtheus;
            
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

            return Listar(where => (where.CodigoPedidoProtheus == CodigoPedido)).ToList();
        }      

        public List<PedidoProtheus> Listar(int StatusPedido,string Transportadora)
        {

            return Listar(where => (where.StatusPedido == StatusPedido)&& (where.Transportadora.Contains(Transportadora))).ToList();
        }

        public List<PedidoProtheus> Listar(int StatusPedido)
        {
              
            return Listar(where=>(where.StatusPedido == StatusPedido)).ToList();
        }        

        public void AtualizaStatus(string Danfe, int StatusPedido)
        {
            PedidoProtheus entidade = (PedidoProtheus)Listar(where => where.Danfe.Contains(Danfe) && where.StatusPedido == 3).FirstOrDefault();  //(from p in context.PedidoProtheus.Where(p => p.Danfe.Contains(Danfe)) select p).FirstOrDefault();
            entidade.StatusPedido = StatusPedido;
            //entidade.DataAlteracao = DateTime.Now;
            Atualizar(entidade); 
        
        }

        public void AtualizaStatus(int CodigoPedido, int StatusPedido)
        {
            PedidoProtheus entidade = (PedidoProtheus)Listar(where => where.CodigoPedidoProtheus== CodigoPedido).FirstOrDefault(); 
            entidade.StatusPedido = StatusPedido;
            //entidade.DataAlteracao = DateTime.Now;
            Atualizar(entidade);
        } 

        #endregion       

    }   

}
