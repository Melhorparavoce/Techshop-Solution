using System;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Repositoy.CodeFirst;
using Model.CodeFirst.Models;
using Techshop.Repositoy.CodeFirst.Interface;
using System.Collections.Generic;
namespace Techshop.Aplication
{
    public class Pedidos
    {
        private PedidosRep objPedidosRep;

        public Pedidos()
        {
            objPedidosRep = new PedidosRep();

        }

        /// <summary>
        /// Inclui Pedidos Espelho Skyhub
        /// </summary>
        public void IncluirPedidosBaseEspelhoSkyhub()
        {
                               
            PedidosRep objPedidosRep = new PedidosRep();
            ItemPedidoRep objOrderItemRep = new ItemPedidoRep();
            OrderApp objOrderApp = new OrderApp();
            

            Order.OrderListResponse list = (Order.OrderListResponse)objOrderApp.Get().AdditionalData;

            int CodigoPedido = 0;



            for (int i = 0; i < list.Total; i++)
            {

                Pedido EntidadePedido = new Pedido();

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

                objPedidosRep.CriarPedido(EntidadePedido);

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
                    //EntidadeItemProduto.Pedido = EntidadePedido;

                  objOrderItemRep.CriarItemPedido(EntidadeItemProduto); 
                                
                }
                CodigoPedido = CodigoPedido + 1;

                string teste = "";         
            }                     

        }
       
        /// <summary>
        /// Inclui pedidos base 
        /// </summary>
        public void InserirPedidosBaseEspelhoProtheus()
        {
            PedidoProtheus entidade = new PedidoProtheus();


           foreach(Pedido item in objPedidosRep.ListarPedidosImportadosSkyhub())
            {
                entidade.CodicaoPagamento = "";
              //  entidade.

            }  
        }


    }

}
