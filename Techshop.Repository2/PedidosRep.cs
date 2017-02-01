using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.SkyHub;
using Model.CodeFirst.Models;
using System.Data.SqlClient;

namespace Techshop.Repositoy.CodeFirst
{
    public class PedidosRep
    {
         TechshopContext context = new TechshopContext();

            public int IncluirPedidosSkyhub(Order domain)
        {
                                  
                Pedido obj = new Pedido();
                                  
                 obj.CodigoVendedor = 0;
                 obj.DescricaoCanal = domain.channel;
                 obj.DescricaoCustoEntrega = Convert.ToDecimal(domain.shipping_cost);
                 obj.DescricaoInterface = Convert.ToDecimal(domain.interest);
                 obj.DescricaoMetodoEntrega = domain.shipping_method;
                 obj.DescricaoStatusSincronizacao = domain.sync_status;
                 obj.DescricaoTotalPedido = Convert.ToDecimal(domain.total_ordered);
                 obj.DataAtualizacao = Convert.ToDateTime(domain.updated_at);
                 obj.DataEstimadaEntrega = Convert.ToDateTime(domain.placed_at);
                 obj.DataLocalizadoDesde = Convert.ToDateTime(domain.estimated_delivery); 
                 obj.IndImportado = 0; 

                context.TEC_PEDIDOS.Add(obj);
                context.SaveChanges();

                return obj.CodigoPedido;    

            }   
        
    }
    

}
