using System;
using Techshop.Repositoy.CodeFirst;
using Techshop.Model;
using System.Configuration;
using Techshop.Aplication.Interface;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain;
using SkyHubAdapter.Domain.SkyHub;
using SkyHubAdapter.Domain.AbsModels;

namespace Techshop.Aplication
{
    public class SkyhubApp
    {

        #region Construtor e Propriedades

            private PedidosProtheusRep objPedidosProtheusRep;
            private OrderApp objOrderApp;
            private LogerroApp objLogerroApp; 
      
        public SkyhubApp()
        {
            objPedidosProtheusRep = new PedidosProtheusRep();
            objOrderApp = new OrderApp();
            objLogerroApp = new LogerroApp();
        }

        #endregion

        #region Métodos


        public void InformarPedidoEnviadoSkyhub()
        {
            try
            {
                foreach (PedidoProtheus item in objPedidosProtheusRep.Listar(6))
                {

                    var newInvoice = new Invoice { key = item.Danfe };
                    var newShipment = new Shipment
                    {
                        code = DateTime.Now.ToString("yyyyMMddHHmmss"),
                        track = new ShipmentTrack { carrier = "JADLOG", method = "Expresso", code = item.CodigoColetaJadlog }
                    };

                    try
                    {

                      ResultProcessing resultado = objOrderApp.PostShipment(item.NumeroEntregaSkyhub.Trim(), newShipment, newInvoice);

                        if (resultado.Success == false)
                        {
                            objLogerroApp.GravarLogErro("Envio ao enviar o pedido: " + item.NumeroEntregaSkyhub, resultado.Message,"");
               
                        }
                        else
                        {

                            objPedidosProtheusRep.AtualizaStatus(item.CodigoPedidoProtheus, 6);
                        }

                    }
                    catch(Exception ex)
                    {
                        objLogerroApp.GravarLogErro("Envio ao enviar o pedido: "+ item.NumeroEntregaSkyhub, "Envio da informações de pedidos enviados Skyhub", ex.Message);

                    }
                }
            }catch(Exception ex)
            {

                objLogerroApp.GravarLogErro("Envio da informações de pedidos enviados Skyhub", "Envio da informações de pedidos enviados Skyhub", ex.Message);

            }               

        }



        public void InformarPedidosEntregueSkyhub()
        {
            try
            {
                foreach (PedidoProtheus item in objPedidosProtheusRep.Listar(6))
                {

                  try
                    {

                        ResultProcessing resultado = objOrderApp.PostDelivery(item.NumeroEntregaSkyhub.Trim());

                        if (resultado.Success == false)
                        {
                            objLogerroApp.GravarLogErro("Erro ao informar entrega de pedido: " + item.NumeroEntregaSkyhub, resultado.Message, "");

                        }
                        else
                        {

                            objPedidosProtheusRep.AtualizaStatus(item.CodigoPedidoProtheus, 7);
                        }

                    }
                    catch (Exception ex)
                    {
                        objLogerroApp.GravarLogErro("Informar entrega de produtos " + item.NumeroEntregaSkyhub, "Informar pedidos entregues skyhub", ex.Message);

                    }
                }
            }
            catch (Exception ex)
            {

                objLogerroApp.GravarLogErro("Envio da informações de pedidos enviados Skyhub", "Envio da informações de pedidos enviados Skyhub", ex.Message);

            }

        }

        #endregion
    }
}
