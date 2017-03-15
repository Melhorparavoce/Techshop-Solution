using System;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Repositoy.CodeFirst;
using Techshop.Model;
using System.Collections.Generic;
using SkyHubAdapter.Domain.AbsModels;
namespace Techshop.Aplication
{
    public class PedidosApp
    {
        #region Propriedades
        private PedidosRep objPedidosRep;
        private PedidosProtheusRep objPedidosProtheusRep = new PedidosProtheusRep();

        public PedidosApp()
        {
            objPedidosRep = new PedidosRep();

        }

        #endregion

        #region Métodos
        public string IncluirPedidosBaseEspelhoSkyhub()
        {
            string Mensagem = "";
            try
            {

                PedidosRep objPedidosRep = new PedidosRep();
                QueueApp objQueueApp = new QueueApp();                
                List<ItemPedidos> listItensProdutos = new List<ItemPedidos>();
                        

                Mensagem = "Erro ao recuperar pedido na fila método: Order objPedidoImportado = (Order)objQueueApp.GetNextOrder().AdditionalData;";
                 Order objPedidoImportado = (Order)objQueueApp.GetNextOrder().AdditionalData;

                if (objPedidoImportado == null)
                    return "Sem Pedidos na Fila de Integração";

                if (objPedidoImportado != null)
                {
                    var EntidadePedido = new Pedido()
                    {

                        IndImportadoProtheus = 0,
                        DescricaoCanal = objPedidoImportado.channel,
                        CodigoSkyhub = objPedidoImportado.code,
                        DescricaoCustoEntrega = Convert.ToDecimal(objPedidoImportado.shipping_cost),
                        DescricaoInteresse = Convert.ToDecimal(objPedidoImportado.interest),
                        DescricaoMetodoEntrega = objPedidoImportado.shipping_method,
                        DescricaoStatusSincronizacao = objPedidoImportado.sync_status,
                        DescricaoTotalPedido = Convert.ToDecimal(objPedidoImportado.total_ordered),
                        DataAtualizacao = Convert.ToDateTime(objPedidoImportado.updated_at),
                        DataEstimadaEntrega = Convert.ToDateTime(objPedidoImportado.placed_at),
                        DataLocalizadoDesde = Convert.ToDateTime(objPedidoImportado.estimated_delivery),
                        DataSincronizacao = DateTime.Now,
                        DescricaoValorCompra = Convert.ToDecimal(objPedidoImportado.total_ordered),
                        // DescricaoInscricaoEstadual = objPedidoImportado.
                        DescricaoCliente = objPedidoImportado.customer.name,
                        DescricaoEmail = objPedidoImportado.customer.email,
                        DescricaoGenero = objPedidoImportado.customer.gender,
                        DescricaoCPF = objPedidoImportado.customer.vat_number,
                        DescricaoTelefone1 = objPedidoImportado.customer.phones[0],
                        // EntidadePedido.DescricaoTelefone2 = objPedidoImportado.customer.phones[1];
                        //  EntidadePedido.DescricaoTelefone3 = objPedidoImportado.customer.phones[2];
                        // EntidadePedido.DescricaoTelefone4 = objPedidoImportado.customer.phones[3];
                        DataNascimento = Convert.ToDateTime(objPedidoImportado.customer.date_of_birth),

                        DescricaoBairro = objPedidoImportado.shipping_address.neighborhood,
                        DescricaoCep = objPedidoImportado.shipping_address.postcode,
                        DescricaoCidade = objPedidoImportado.shipping_address.city,
                        DescricaoDetalhes = objPedidoImportado.shipping_address.detail,
                        DescricaoNome = objPedidoImportado.shipping_address.full_name,
                        DescricaoPais = objPedidoImportado.shipping_address.country,
                        DescricaoRegiao = objPedidoImportado.shipping_address.region,
                        DescricaoRua = objPedidoImportado.shipping_address.street, 
                        DescricaoNumero = objPedidoImportado.shipping_address.number,


                    };

                    for (int j = 0; j < objPedidoImportado.items.Count; j++)
                    {
                        var EntidadeItemProduto = new ItemPedidos()
                        {

                            CodigoId = objPedidoImportado.items[j].id,
                            DescricaoPrecoEspecial = Convert.ToDecimal(objPedidoImportado.items[j].special_price),
                            DescricaoPrecoOriginal = Convert.ToDecimal(objPedidoImportado.items[j].original_price),
                            DescricaoProduto = objPedidoImportado.items[j].name,
                            DescricaoQuantidade = Convert.ToDecimal(objPedidoImportado.items[j].qty),
                        };

                        listItensProdutos.Add(EntidadeItemProduto);
                    }

                    EntidadePedido.ItensPedidos = listItensProdutos;

                    if (objPedidosRep.Listar(objPedidoImportado.code).Count == 0 && objPedidoImportado.status.type == "APPROVED")
                    {
                        Mensagem = "Erro ao criar pedido na base espelho Skyhub Método: objPedidosRep.Criar(EntidadePedido),Pedido:" + objPedidoImportado.code;
                        objPedidosRep.Criar(EntidadePedido);

                    }

                    Mensagem = "Erro ao retirar pedido da fila, método objQueueApp.DeleteOrder(objPedidoImportado.code) ,Pedido:" + objPedidoImportado.code;
                    objQueueApp.DeleteOrder(objPedidoImportado.code);
                 

                    return "";
                }

                
            } 
                //Fim do Loop
            catch(Exception ex)
            {
                LogerroRep objLogerroRep = new LogerroRep();

                var Erro = new Logerro
                {
                    DescricaoErro = Mensagem,
                    DescricaoExcecao = ex.InnerException.Message,
                    DataGeracao = DateTime.Now,
                    DescricaoOperacao="Importação de Pedidos Skyhub" 
                };

                objLogerroRep.Criar(Erro);

                return Mensagem;
          
            }

            return "";
        }    

        public void AlteraStatusPedidosAprovado(string pedido)
        {  
              OrderApp objOrderApp = new OrderApp();
              ResultProcessing retorno = objOrderApp.PostApproval(pedido);
             
             
        }             

        public bool AtualizaPedido(string CodigoPedido)
        {
            OrderApp objOrderApp = new OrderApp();
            ResultProcessing objResultProcessing = objOrderApp.PutExported(CodigoPedido);
     
            return false;
        }         

        public void IndicaPedidoImportadoBaseEspelhoProtheus(int CodigoPedido)
        {
            Pedido entidade = objPedidosRep.Recuperar(CodigoPedido);
            entidade.IndImportadoProtheus = 1;
            objPedidosRep.Atualizar(entidade);


        }

        public void AlteraStatusPedidoAprovado()
        {
                PedidosRep objPedidosRep = new PedidosRep();
                QueueApp objQueueApp = new QueueApp();
                OrderApp objOrderApp = new OrderApp();

                Order objPedidoImportado = (Order)objQueueApp.GetNextOrder().AdditionalData;
           
                objOrderApp.PostApproval(objPedidoImportado.code);
                objQueueApp.DeleteOrder(objPedidoImportado.code);             
      
        }


        #endregion

    }

}
