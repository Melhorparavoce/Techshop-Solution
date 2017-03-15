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
    public partial class frmProdutoCadastro : Form
    {
        public frmProdutoCadastro()
        {
            InitializeComponent();
        }


        private static ResultProcessing PostProducts()
        {
            List<Marketplaces> list = new List<Marketplaces>();
            Marketplaces obj = new Marketplaces();
            obj.Name = "Americanas";
            obj.Href = "150";
            list.Add(obj);

            Marketplaces obj2 = new Marketplaces();
            obj2.Name = "Submarino";
            obj2.Href = "100";
            list.Add(obj2);

            var newProduct = new Product
            {
                marketplaces = list,
                description = "ROTEADOR WIRELESS 150MBPS ASUS RT-N10",
                cost = 200,
                ean = "4712196175818",
                height = 32,
                width = 10,
                length = 39,
                weight = 3.1,
                name = "ROTEADOR WIRELESS 6666666666",
                price = 300.70,
                promotional_price = null,
                qty = 5,
                sku = "ROTASU00333",
                status = "enabled",
                categories = new List<Category> { new Category { code = "ROT", name = "Roteadores" } },
                brand = "ASUS",
                specifications = new List<Specification>
                {
                    new Specification {key = "color", value = "Preto"}
                }
            };
            return new ProductApp().Post(newProduct);
        
        }


        private void btnCriarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                ResultProcessing result = PostProducts();

                string teste = "";


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
