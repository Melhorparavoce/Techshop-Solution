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
    public partial class frmRetiraPedidoFila : Form
    {
        public frmRetiraPedidoFila()
        {
            InitializeComponent();
        }

        private void btnCriarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                QueueApp obj = new QueueApp();

                ResultProcessing retorno = obj.DeleteOrder(textBox2.Text);

                MessageBox.Show(retorno.Message);

            }   catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
    }
}
