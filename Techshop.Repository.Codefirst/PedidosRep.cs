using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using System.Data.SqlClient;
using Techshop.Model;

namespace Techshop.Repositoy.CodeFirst
{
    public class PedidosRep : RepositorioGenerico<Pedido>
    {
        private TechshopContext context;


        public PedidosRep()
        {     
            context = new TechshopContext();
        }     


        public int CriarPedido(Pedido EntidadePedido)
        {

            context.Pedidos.Add(EntidadePedido);
            context.SaveChanges();

            return EntidadePedido.CodigoPedido;
          //  return context.  
        }


       public int IncluirPedidosSkyhub(Order domain)
        {
                                  
                Pedido obj = new Pedido();
                                  
                 
                 obj.DescricaoCanal = domain.channel;
                 obj.CodigoSkyhub = domain.code;
                 obj.DescricaoCustoEntrega = Convert.ToDecimal(domain.shipping_cost);
                 obj.DescricaoInteresse = Convert.ToDecimal(domain.interest);
                 obj.DescricaoMetodoEntrega = domain.shipping_method;
                 obj.DescricaoStatusSincronizacao = domain.sync_status;
                 obj.DescricaoTotalPedido = Convert.ToDecimal(domain.total_ordered);
                 obj.DataAtualizacao = Convert.ToDateTime(domain.updated_at);
                 obj.DataEstimadaEntrega = Convert.ToDateTime(domain.placed_at);
                 obj.DataLocalizadoDesde = Convert.ToDateTime(domain.estimated_delivery);
                 obj.DataSincronizacao = DateTime.Now;
                 obj.DescricaoValorCompra = Convert.ToDecimal(domain.total_ordered);                                    

                 obj.IndImportadoProtheus = 0; 

                context.Pedidos.Add(obj);
                context.SaveChanges();

                return obj.CodigoPedido;    

            }         

        public List<Pedido> ListarPedidosImportadosSkyhub()
        {
            return Listar(where => where.IndImportadoProtheus == 0).ToList();
            
        }
        
    }
    

}
