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
    public partial class frmAlteracaoStatusPedidoSkyhub : Form
    {

        #region Proriedades
        JadlogApp objApp = new JadlogApp();

        public frmAlteracaoStatusPedidoSkyhub()
        {
            InitializeComponent();
        }


        #endregion

        #region Eventos
    
        #endregion

        #region Métodos

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
                        special_price = 2000,
                        original_price =2000
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmCadastroPedidosSkyhub_Load(object sender, EventArgs e)
        {

        }

        private void btnCriarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                string Pedido = txtCodigoPedido.Text;
                ResultProcessing retorno = new ResultProcessing();


                switch (cmbStatus.Text.ToString())
                {
                    case "Aprovado":
                        {
                            retorno = PostOrderApproval(Pedido);
                            break;
                        }
                    case "Cancelado":
                        {
                            retorno = PostOrderCancel(Pedido);
                            break;
                        }
                    case "Entregue":
                        {
                            retorno = PostOrderDelivery(Pedido);
                            break;
                        }
                    case "Exportado":
                        {
                            retorno = PutOrderExported(Pedido);
                            break;
                        }
                    case "Faturado":
                        {
                            retorno = PostOrderInvoice(Pedido);
                            break;
                        }

                    case "Enviado":
                        {
                            retorno = PostOrderShipment(Pedido);
                            break;
                        }
                }


                if (retorno.Success == true)
                {
                    MessageBox.Show("Pedido " + cmbStatus.Text +"Com Sucesso!");

                }  else
                {
                    MessageBox.Show(retorno.Message);

                }                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
        
}
