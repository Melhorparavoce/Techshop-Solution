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
    public partial class frmCancelaPedidoJadLog : Form
    {

        #region Proriedades
        JadlogApp objApp = new JadlogApp();

        public frmCancelaPedidoJadLog()
        {
            InitializeComponent();
        }


        #endregion

        #region Eventos
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string mensagem = objApp.CancelarNotaJadLog(textBox1.Text);


                objApp.EnviarInformacoesTransportadora(11);

                MessageBox.Show("");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
        
}
