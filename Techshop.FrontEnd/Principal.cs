using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.AbsModels;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Aplication;
using Techshop.Repositoy.CodeFirst;

namespace Techshop.FrontEnd
{
    public partial class Principal : Form
    {

        #region Proriedades

        public Principal()
        {
            InitializeComponent();
        }

        #endregion

        #region Métodos Skyhub

        #region Orders
        private static ResultProcessing PostOrders()
        {
            var order = new Order
            {
                channel = "Mercadolivre",
                items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        id = "NOTACE00032",
                        qty = 1,
                        special_price = 2000
                    }
                },
                customer = new Customer
                {
                    name = "Alberto Rezende",
                    date_of_birth = "10/10/1977",
                    email = "alberto@techshop.com.br",
                    gender = "M",
                    phones = new List<string> { "(31) 9929-4185" },
                    vat_number = "98113445587"
                },
                billing_address = new Address
                {
                    full_name = "Alberto Rezende",
                    street = "Rua Rio Mossoro",
                    number = "1082",
                    detail = "Sem detalhes",
                    neighborhood = "Riacho",
                    city = "Contagem",
                    region = "MG",
                    country = "BR",
                    postcode = "32265220"
                },
                shipping_address = new Address
                {
                    full_name = "Alberto Rezende",
                    street = "Rua Rio Mossoro",
                    number = "1082",
                    detail = "Sem detalhes",
                    neighborhood = "Riacho",
                    city = "Contagem",
                    region = "MG",
                    country = "BR",
                    postcode = "32265220"
                },
                shipping_method = "Jade",
                estimated_delivery = DateTime.Now.AddDays(5).Date,
                shipping_cost = 25,
                interest = 0,
                status = new Status()

            };

            return new OrderApp().Post(order);
        }

        private static ResultProcessing PostOrderApproval(string code)
        {
            return new OrderApp().PostApproval(code);
        }

        private static ResultProcessing PutOrderExported(string code)
        {
            return new OrderApp().PutExported(code);
        }

        private static ResultProcessing PostOrderInvoice(string code)
        {
            var newInvoice = new Invoice { key = "31161108351293000163550010002090771001595456" };
            return new OrderApp().PostInvoice(code, newInvoice);
        }

        private static ResultProcessing PostOrderShipment(string code)
        {
            var newInvoice = new Invoice { key = "31161108351293000163550010002091271001645457" };
            var newShipment = new Shipment
            {
                code = DateTime.Now.ToString("yyyyMMddHHmmss"),
                track = new ShipmentTrack { carrier = "JADLOG", method = "Expresso", code = "JAD12345678" }
            };
            return new OrderApp().PostShipment(code, newShipment, newInvoice);
        }

        private static ResultProcessing PostOrderDelivery(string code)
        {
            return new OrderApp().PostDelivery(code);
        }

        private static ResultProcessing PostOrderCancel(string code)
        {
            return new OrderApp().PostCancel(code);
        }

        private static ResultProcessing GetOrders(string code)
        {
            return code == string.Empty ? new OrderApp().Get() : new OrderApp().Get(code);
        }

        #endregion

        #region Categories
        private static ResultProcessing PostCategories()
        {
            var newCategory = new Category { code = "0006", name = "Desktops" };
            return new CategoryApp().Post(newCategory);
        }

        private static ResultProcessing GetCategories()
        {
            return new CategoryApp().Get();
        }

        private static ResultProcessing DeleteCategories(string code)
        {
            return new CategoryApp().Delete(code);
        }
        #endregion

        #region Products
        private static ResultProcessing PostProducts()
        {
            //var newProduct = new Product
            //{
            //    description = "NOTEBOOK Q.C N3150 4GB HD500 ACER 14.1\" W10 VERMELHO ES1-431 Description",
            //    cost = 0,
            //    ean = "4712196175818",
            //    height = 32,
            //    width = 10,
            //    length = 39,
            //    weight = 3.1,
            //    name = "NOTEBOOK Q.C N3150 4GB HD500 ACER 14.1\" W10 VERMELHO ES1-431",
            //    price = 2400,
            //    promotional_price = null,
            //    qty = 5,
            //    sku = "NOTACE00032",
            //    status = "enabled",
            //    categories = new List<Category> { new Category { code = "0001", name = "Notebooks" } }
            //};
            //return new ProductApp().Post(newProduct);

            var newProduct = new Product
            {
                description = "ROTEADOR WIRELESS 150MBPS ASUS RT-N10",
                cost = 200,
                ean = "4712196175818",
                height = 32,
                width = 10,
                length = 39,
                weight = 3.1,
                name = "ROTEADOR WIRELESS 150MBPS ASUS RT-N10",
                price = 300.70,
                promotional_price = null,
                qty = 5,
                sku = "ROTASU00001",
                status = "enabled",
                categories = new List<Category> { new Category { code = "ROT", name = "Roteadores" } },
                brand = "ASUS",
                specifications = new List<Specification>
                {
                    new Specification {key = "color", value = "Preto"}
                }
            };
            return new ProductApp().Post(newProduct);
            //var newProduct = new Product
            //{
            //    description = "TV 32\" LED AOC LE32H1461 / 20 HDMI USB CONVERSOR INT BIV Description",
            //    cost = 0,
            //    ean = "TLVAOC00005",
            //    height = 54.05,
            //    width = 83.05,
            //    length = 0.14,
            //    weight = 0.834,
            //    name = "TV 32\" LED AOC LE32H1461 / 20 HDMI USB CONVERSOR INT BIV",
            //    price = 1562.9,
            //    promotional_price = null,
            //    qty = 2,
            //    sku = "TLVAOC00011",
            //    status = "enabled",
            //    categories = new List<Category> { new Category { code = "0002", name = "Tvs" } }
            //};
            //return new ProductApp().Post(newProduct);
        }

        private static ResultProcessing GetProducts(string code)
        {
            return code == string.Empty ? new ProductApp().Get() : new ProductApp().Get(code);
        }

        private static ResultProcessing DeleteProducts(string code)
        {
            return new ProductApp().Delete(code);
        }

        private static ResultProcessing PutProducts()
        {

            //var product = new Product
            //{
            //    description = "Teste de Alteração de Campos",
            //    cost = 0,
            //    ean = "4712196175818",
            //    height = 32,
            //    width = 10,
            //    length = 39,
            //    weight = 3.1,
            //    name = "NOTEBOOK Q.C N3150 4GB HD500 ACER 14.1\" W10 VERMELHO ES1-431",
            //    price = 1300,
            //    promotional_price = null,
            //    qty = 5,
            //    sku = "NOTACE00034",
            //    status = "enabled",
            //    categories = new List<Category> { new Category { code = "0001", name = "Notebooks" } }
            //};
            var product = new Product
            {
                description = "NOTEBOOK Q.C N3150 4GB HD500 ACER 14.1\" W10 VERMELHO ES1-431 Description",
                cost = 0,
                ean = "4712196175818",
                height = 32,
                width = 10,
                length = 39,
                weight = 3.1,
                name = "NOTEBOOK Q.C N3150 4GB HD500 ACER 14.1\" W10 VERMELHO ES1-431",
                price = 2400,
                promotional_price = null,
                qty = 5,
                sku = "NOTACE00032",
                status = "enabled",
                categories = new List<Category>
                {
                    new Category { code = "0001", name = "Notebooks" },
                    new Category { code = "0006", name = "Desktops" },
                    new Category { code = "0007", name = "Servidores" }
                }
            };
            return new ProductApp().Put(product);
        }
        #endregion

        #region Tipo de Status de Pedidos
        private static ResultProcessing GetStatusType()
        {
            return new StatusTypeApp().Get();
        }
        #endregion

        #region Status de Pedidos

        private static ResultProcessing PostOrderStatus()
        {
            var newStatus = new Status() { code = "D", label = "Entregue", type = "DELIVERED" };
            return new StatusApp().Post(newStatus);
        }

        private static ResultProcessing GetOrderStatus(string code = "")
        {
            return code == string.Empty ? new StatusApp().Get() : new StatusApp().Get(code);
        }

        #endregion

        #region Market Places
        private static ResultProcessing GetMarketPlaces()
        {
            return new MarketplacesApp().Get();
        }
        #endregion

        #region Freights

        private static ResultProcessing GetFreights()
        {
            return new FreightApp().Get();
        }

        #endregion

        #region Queue

        private static ResultProcessing GetQueue()
        {
            return new QueueApp().GetNextOrder();
        }

        private static ResultProcessing DeleteQueue(string code)
        {
            return new QueueApp().DeleteOrder(code);
        }
        #endregion

        #endregion

        #region Eventos
        private void btnImportPedidosSkyhub_Click(object sender, EventArgs e)
        {
            try { 
            PedidosApp objApp = new PedidosApp();
            objApp.IncluirPedidosBaseEspelhoSkyhub();
                MessageBox.Show("Pedidos Importados Com Sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:"+ex.Message);

            }
        }

        private void btnImportPedidoProtheus_Click(object sender, EventArgs e)
        {
            try
            {

                PedidosApp objApp = new PedidosApp();
                objApp.IncluirPedidosBaseEspelhoProtheus();

                MessageBox.Show("Pedidos Importados Para a Base do Protheus Com Sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message);

            }
        }

        private void btnApagaPedidosBaseSkyhub_Click(object sender, EventArgs e)
        {
            try
            {

                PedidosRep objPedidosRep = new PedidosRep();
                ItemPedidoRep objItemPedidoRep = new ItemPedidoRep();

                objPedidosRep.ExcluirTodos();
                objItemPedidoRep.ExcluirTodos();

                MessageBox.Show("Pedidos Excluídos Base Techshop/Skyhub Com Sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PedidosProtheusRep objPedidosProtheusRep = new PedidosProtheusRep();
                ItemPedidosProtheusRep objItemPedidoProtheusRep = new ItemPedidosProtheusRep();

                objItemPedidoProtheusRep.ExcluirTodos();
                objPedidosProtheusRep.ExcluirTodos();
                MessageBox.Show("Pedidos Excluídos Base Techshop/Protheus Com Sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message);

            }
        }

        #endregion

    }
        
}
