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
    public partial class frmCadastroPedidosSkyhub : Form
    {

        #region Proriedades
        JadlogApp objApp = new JadlogApp();

        public frmCadastroPedidosSkyhub()
        {
            InitializeComponent();
        }


        #endregion

        #region Eventos
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var order = new Order
                {
                    channel = cmbMarketPlace.Text,
                    items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        id = txtIdProduto.Text,
                        qty = Convert.ToDouble(txtIdQuantidade.Text),
                        special_price = Convert.ToDouble(txtPreco.Text)
                    }
                },
                    customer = new Customer
                    {
                        name = txtNomeCliente.Text,
                        date_of_birth = txtDataNiver.Text,
                        email = txtEmail.Text,
                        gender = txtSexo.Text,
                        phones = new List<string> { txtTelefone.Text },
                        vat_number = txtCpf.Text
                    },
                    billing_address = new Address
                    {
                        full_name = txtNomeEndereco.Text,
                        street = txtRua.Text,
                        number = txtNumero.Text,
                        detail = "Sem detalhes",
                        neighborhood =txtBairro.Text,
                        city = txtCidade.Text,
                        region = txtEstado.Text,
                        country = txtPais.Text,
                        postcode = txtCep.Text
                    },
                    shipping_address = new Address
                    {
                        full_name = txtNomeEndereco.Text,
                        street = txtRua.Text,
                        number = txtNumero.Text,
                        detail = "Sem detalhes",
                        neighborhood = txtBairro.Text,
                        city = txtCidade.Text,
                        region = txtEstado.Text,
                        country = txtPais.Text,
                        postcode = txtCep.Text
                    },
                    shipping_method = "Jade",
                    estimated_delivery = DateTime.Now.AddDays(5).Date,
                    shipping_cost = 25,
                    interest = 0,
                    status = new Status()

                };

                DateTime data = DateTime.Now.AddDays(14).Date;

                OrderApp objOrderApp = new OrderApp();

                ResultProcessing retorno = objOrderApp.Post(order);

                if (retorno.Success == true)
                {

                    MessageBox.Show("Pedido Criado Com Sucesso");
                }
                else
                {
                    MessageBox.Show("Erro:" + retorno.Message);

                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);                                                
            }
        }

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
    }
        
}
