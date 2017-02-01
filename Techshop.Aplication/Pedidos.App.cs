using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Repositoy.CodeFirst;
using Model.CodeFirst.Models;
using Techshop.Repositoy.CodeFirst.Interface;
namespace Techshop.Aplication
{
    public class Pedidos
    {
        private IRepository<Pedido> repositorio = new Repository<Pedido>();

        

        /// <summary>
        /// Inclui Pedidos Espelho Skyhub
        /// </summary>
        public void IncluirPedidosBaseTemporaria()
        {
            Pedido Entidade = new Pedido();

            PedidosRep objOrderRep = new PedidosRep();
            //ItemPedidoRep objOrderItemRep = new ItemPedidoRep();
            //EnderecoRep objAddressRep = new EnderecoRep();
            ClienteRep objCustomerRep = new ClienteRep();
            OrderApp objOrderApp = new OrderApp();

            int CodigoPedido = 0;

            //Busca Informações 
            Order.OrderListResponse list = (Order.OrderListResponse)objOrderApp.Get().AdditionalData;

            for (   int i = 0; i < list.Total; i++)
            {

                //Insere Pedidos
                CodigoPedido = objOrderRep.IncluirPedidosSkyhub((Order)list.Orders[i]);

                string teste = "";

                // Insere Itens Pedidos
              /*  for (int j = 0; j < list.Orders[i].items.Count; j++)
                {
                    OrderItem domainOrderItem = (OrderItem)list.Orders[i].items[j];
                    domainOrderItem.CodigoPedido = CodigoPedido;
                    objOrderItemRep.incluir(domainOrderItem);
                }

                // Insere Endereço Faturamento
                Address domainAdressBilling = (Address)list.Orders[i].billing_address;
                domainAdressBilling.TipoEndereco = 1;
                domainAdressBilling.DescricaoEndereco = "Endereço de Faturamento";
                domainAdressBilling.CodigoPedido = CodigoPedido;
                objAddressRep.incluir(domainAdressBilling);


                // Insere Endereço Remessa
                Address domainAdressShipping = (Address)list.Orders[i].shipping_address;
                domainAdressShipping.TipoEndereco = 2;
                domainAdressShipping.DescricaoEndereco = "Endereço Para Remessa";
                domainAdressShipping.CodigoPedido = CodigoPedido;
                objAddressRep.incluir(domainAdressShipping);

                //Insere informações cliente 
                Customer domainCustomer = (Customer)list.Orders[i].customer;
                domainCustomer.CodigoPedido = CodigoPedido;

                // Skyhub permite até 4 telefones
                List<string> ListTelefones = new List<string>();
                int totalTelefones = list.Orders[i].customer.phones.Count;
                for (int h = 0; h < 4; h++)
                {
                    if (h < totalTelefones)
                        ListTelefones.Add(list.Orders[i].customer.phones[h]);
                    else
                        ListTelefones.Add("");
                }
                domainCustomer.phones = ListTelefones;
                objCustomerRep.incluir(domainCustomer);


                // 


                string teste = "1"; */
            }


        }
    }

}
