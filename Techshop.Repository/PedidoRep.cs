using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;

namespace Techshop.Repository
{
    public class PedidoRep
    {
        TechshopEntities1 context = new TechshopEntities1();

      public int incluir(Order domain)
        {
            TEC_PEDIDOS obj = new TEC_PEDIDOS();

            obj.COD_CANAL = domain.code;
            obj.COD_VENDEDOR = 0;
            obj.DSC_CANAL = domain.channel;
            obj.DSC_CUSTO_ENTREGA = Convert.ToDecimal(domain.shipping_cost);
            obj.DSC_INTERECE = Convert.ToDecimal(domain.interest);
            obj.DSC_METODO_ENTREGA = domain.shipping_method;
            obj.DSC_STATUS_SINCRONIZACAO = domain.sync_status;
            obj.DSC_TOTAL_PEDIDO = Convert.ToDecimal(domain.total_ordered);
            obj.DTA_ATUALIZACAO = Convert.ToDateTime(domain.updated_at);
            obj.DTA_ESTIMADA_ENTREGA = Convert.ToDateTime(domain.placed_at);
            obj.DTA_LOCALIZADO_DESDE = Convert.ToDateTime(domain.estimated_delivery);
            obj.IND_IMPORTADO = 0;
            context.TEC_PEDIDOS.Add(obj);
            context.SaveChanges();

            return obj.COD_PEDIDO;

           
        }            

    }
}
