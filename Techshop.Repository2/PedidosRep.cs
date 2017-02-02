using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using Model.CodeFirst.Models;
using System.Data.SqlClient;

namespace Techshop.Repositoy.CodeFirst
{
    public class PedidosRep
    {
        private TechshopContext context;


        public PedidosRep()
        {

            context = new TechshopContext();

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

                context.Pedido.Add(obj);
                context.SaveChanges();

                return obj.CodigoPedido;    

            }   
        
    }
    

}
