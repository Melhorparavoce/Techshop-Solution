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
    public partial class frmProdutoConsulta : Form
    {
        public frmProdutoConsulta()
        {
            InitializeComponent();
        }

        private void btnCriarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoApp obj = new ProdutoApp();
               // obj.Listar(txtSku.Text, "", 0, 0);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
