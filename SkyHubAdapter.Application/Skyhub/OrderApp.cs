using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using SkyHubAdapter.Application.Interfaces;
using SkyHubAdapter.Domain.AbsModels;
using SkyHubAdapter.Domain.SkyHub;
using System.Collections.Generic;


namespace SkyHubAdapter.Application
{
    public class OrderApp 
    {
        private const string Uri = "orders";
                          
        /// <summary>
        /// Retorna todos os pedidos
        /// </summary>
        /// <returns>
        /// 200 Requisição executada com sucesso
        /// 401	Erro de autenticação	
        /// 404	Recurso não encontrado
        /// 500	Erro na API
        /// </returns>
        public ResultProcessing Get(string code = "")
        {
            return code == string.Empty ?
                ClientHelper.Get<Order.OrderListResponse>(Uri, "?filters[statuses]=Aprovado&filters[sync_status][]=NOT_SYNCED", false) :
                ClientHelper.Get<Order>(Uri, code, false);

            
        }

        /// <summary>
        /// Inclui um pedido para teste
        /// </summary>
        /// <returns>
        /// 201	Requisição executada com sucesso	
        /// 400	Requisição mal-formada	
        /// 401	Erro de autenticação	
        /// 403	Erro de autorização	
        /// 422	Erro semântico	
        /// 500	Erro na API
        /// </returns>
        public ResultProcessing Post(TestOrder newOrder)
        {
            return ClientHelper.Post(newOrder, Uri);
            //var client = new SkyHubClient();
            //var result = new ResultProcessing();
            //var json = JsonConvert.SerializeObject(newOrder);
            //var queryString = new StringContent(json);
            ////var response = client.PostAsJsonAsync("orders", newOrder).Result;
            //var response = client.PostAsync("orders", queryString).Result;

            //result.Success = response.IsSuccessStatusCode;
            //result.StatusCode = response.StatusCode;
            //result.Message = response.Content.ReadAsStringAsync().Result;

            //return result;
        }

        public ResultProcessing PostApproval(string code)
        {
            return ClientHelper.Post(new {status = "A"}, Uri + "/" + code + "/approval");
        }

        public ResultProcessing PostInvoice(string code, Invoice invoice)
        {
            return ClientHelper.Post(new { invoice }, Uri + "/" + code + "/invoice");
        }

        public ResultProcessing PostShipment(string code, Shipment shipment, Invoice invoice)
        {
            return ClientHelper.Post(new { status = "S", shipment, invoice }, Uri + "/" + code + "/shipments");
        }

        public ResultProcessing PostDelivery(string code)
        {
            return ClientHelper.Post(new { status = "D" }, Uri + "/" + code + "/delivery");
        }

        public ResultProcessing PostCancel(string code)
        {
            return ClientHelper.Post(new { status = "C" }, Uri + "/" + code + "/cancel");
        }

        public ResultProcessing PutExported(string code, bool exported = true)
        {
            return ClientHelper.Put(new { exported }, Uri + "/" + code + "/exported");
        }

        public ResultProcessing Post(Order newModel)
        {
            return ClientHelper.Post(newModel, Uri);
        }

        public ResultProcessing Put(Order model)
        {
            return ClientHelper.Put(model, Uri);
        }

        public ResultProcessing Delete(string code)
        {
            return ClientHelper.Delete(Uri, code);
        }
    }
}
