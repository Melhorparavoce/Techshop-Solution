using System;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Repositoy.CodeFirst;
using Techshop.Model;
using System.Collections.Generic;
using Protheus.Repository;
namespace Techshop.Aplication
{
    public class PedidosApp
    {
        #region Propriedades
        private PedidosRep objPedidosRep;
        public PedidosApp()
        {
            objPedidosRep = new PedidosRep();

        }

        #endregion

        #region Métodos
        public void IncluirPedidosBaseEspelhoSkyhub()
        {
                               
            PedidosRep objPedidosRep = new PedidosRep();
            ItemPedidoRep objOrderItemRep = new ItemPedidoRep();
            OrderApp objOrderApp = new OrderApp();
            

            Order.OrderListResponse list = (Order.OrderListResponse)objOrderApp.Get().AdditionalData;

         
            for (int i = 0; i < list.Total; i++)
            {

                Pedido EntidadePedido = new Pedido();

                EntidadePedido.IndImportadoProtheus = 0;
                EntidadePedido.DescricaoCanal = list.Orders[i].channel;
                EntidadePedido.CodigoSkyhub = list.Orders[i].code;
                EntidadePedido.DescricaoCustoEntrega = Convert.ToDecimal(list.Orders[i].shipping_cost);
                EntidadePedido.DescricaoInteresse = Convert.ToDecimal(list.Orders[i].interest);
                EntidadePedido.DescricaoMetodoEntrega = list.Orders[i].shipping_method;
                EntidadePedido.DescricaoStatusSincronizacao = list.Orders[i].sync_status;
                EntidadePedido.DescricaoTotalPedido = Convert.ToDecimal(list.Orders[i].total_ordered);
                EntidadePedido.DataAtualizacao = Convert.ToDateTime(list.Orders[i].updated_at);
                EntidadePedido.DataEstimadaEntrega = Convert.ToDateTime(list.Orders[i].placed_at);
                EntidadePedido.DataLocalizadoDesde = Convert.ToDateTime(list.Orders[i].estimated_delivery);
                EntidadePedido.DataSincronizacao = DateTime.Now;
                EntidadePedido.DescricaoValorCompra = Convert.ToDecimal(list.Orders[i].total_ordered);

                EntidadePedido.DescricaoCliente = list.Orders[i].customer.name;
                EntidadePedido.DescricaoEmail = list.Orders[i].customer.email;
                EntidadePedido.DescricaoGenero = list.Orders[i].customer.gender;
                EntidadePedido.DescricaoCPF = list.Orders[i].customer.vat_number;
                EntidadePedido.DescricaoTelefone1 = list.Orders[i].customer.phones[0];
              //  EntidadePedido.DescricaoTelefone2 = list.Orders[i].customer.phones[1];
              //  EntidadePedido.DescricaoTelefone3 = list.Orders[i].customer.phones[2];
              //  EntidadePedido.DescricaoTelefone4 = list.Orders[i].customer.phones[3];
                EntidadePedido.DataNascimento = Convert.ToDateTime(list.Orders[i].customer.date_of_birth);

                EntidadePedido.DescricaoBairro = list.Orders[i].shipping_address.neighborhood;
                EntidadePedido.DescricaoCep = list.Orders[i].shipping_address.postcode;
                EntidadePedido.DescricaoCidade = list.Orders[i].shipping_address.city;
                EntidadePedido.DescricaoDetalhes = list.Orders[i].shipping_address.detail;
                EntidadePedido.DescricaoNome = list.Orders[i].shipping_address.full_name;
                EntidadePedido.DescricaoPais = list.Orders[i].shipping_address.country;
                EntidadePedido.DescricaoRegiao = list.Orders[i].shipping_address.region;
                EntidadePedido.DescricaoRua = list.Orders[i].shipping_address.street;

                int CodigoPedido = objPedidosRep.CriarPedido(EntidadePedido);

                List<ItemPedidos> listItensProdutos = new List<ItemPedidos>();

                for (int j = 0; j < list.Orders[i].items.Count; j++)
                {
                    ItemPedidos EntidadeItemProduto = new ItemPedidos();

                    EntidadeItemProduto.CodigoPedido = CodigoPedido;
                    EntidadeItemProduto.CodigoId = list.Orders[i].items[j].id;
                    EntidadeItemProduto.DescricaoPrecoEspecial = Convert.ToDecimal(list.Orders[i].items[j].special_price);
                    EntidadeItemProduto.DescricaoPrecoOriginal = Convert.ToDecimal(list.Orders[i].items[j].original_price);
                    EntidadeItemProduto.DescricaoProduto = list.Orders[i].items[j].name;
                    EntidadeItemProduto.DescricaoQuantidade = Convert.ToDecimal(list.Orders[i].items[j].qty);
                    
                  objOrderItemRep.CriarItemPedido(EntidadeItemProduto); 
                                
                }
                
            }                     

        }                                              

        public void IncluirPedidosBaseEspelhoProtheus()
        {
            PedidosRep obj = new PedidosRep();
            PedidosProtheusRep objPedidosProtheusRep = new PedidosProtheusRep();
            ItemPedidoRep objItemPedidoRep = new ItemPedidoRep();
            ItemPedidosProtheusRep objItemPedidoProtheusRep = new ItemPedidosProtheusRep();
            VendedorRep objVendedorRep = new VendedorRep();
            TransportadoraRep objTransportadoraRep = new TransportadoraRep();
            VendedorApp objVendedorApp = new VendedorApp();
            MarketplaceApp objMarketplaceApp = new MarketplaceApp();
            string CodigoParceiro = "";

            foreach (Pedido item in obj.ListarPedidosImportadosSkyhub())
            {
                CodigoParceiro = objMarketplaceApp.RetornaParceiro(item.DescricaoCanal);

                var entidadeProtheus = new PedidoProtheus
                {

                    TipoPedido = "N",
                    TipoFrete = "C", 
                    CodigoTransportadora = objTransportadoraRep.RetornaTransportadora(item.DescricaoCep, item.DescricaoRegiao),
                    CodigoTabelaPrecos = "07",
                    Parceiro = CodigoParceiro,
                    DescricaoCanal = item.DescricaoCanal,
                    NumeroEntregaSkyhub = item.CodigoSkyhub,
                    DescricaoCliente = item.DescricaoCliente,
                    DescricaoEmail = item.DescricaoEmail,
                    DescricaoGenero = item.DescricaoGenero,
                    DescricaoCPF = item.DescricaoCPF,
                    DescricaoTelefone1 = item.DescricaoTelefone1,
                    DescricaoTelefone2 = item.DescricaoTelefone2,
                    DescricaoTelefone3 = item.DescricaoTelefone3,
                    DescricaoTelefone4 = item.DescricaoTelefone4,
                    DataNascimento = item.DataNascimento,
                    DescricaoBairro = item.DescricaoBairro,
                    DescricaoCep = item.DescricaoCep,
                    DescricaoCidade = item.DescricaoCidade,
                    DescricaoDetalhes = item.DescricaoDetalhes,
                    DescricaoNome = item.DescricaoNome,
                    DescricaoPais = item.DescricaoPais,
                    DescricaoRegiao = item.DescricaoRegiao,
                    DescricaoRua = item.DescricaoRua,
                    MensagemErro = "",
                    MensagemErroDetalhada = "",
                    StatusImportacao = "1"

                };

                foreach (ItemPedidos itemPedido in objItemPedidoRep.Listar(item.CodigoPedido))
                {

                    
                   entidadeProtheus.CodigoVendendor = objVendedorApp.RetornaVendedor(CodigoParceiro, itemPedido.CodigoId);

                    var EntidadePedidosProtheus = new ItemPedidoProtheus
                    {
                        SkuProduto = itemPedido.CodigoId,
                        Quantidade = itemPedido.DescricaoQuantidade.ToString(),
                        Preco = itemPedido.DescricaoPrecoOriginal.ToString(),
                    };

                    objItemPedidoProtheusRep.Criar(EntidadePedidosProtheus);

                }

                objPedidosProtheusRep.Criar(entidadeProtheus);

           }               
          

        }

        #endregion
       
    }

}
