using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.AbsModels;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Aplication;
using Techshop.Repositoy.CodeFirst;
using Techshop.Model;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Techshop.FrontEnd
{
    public partial class Principal : Form
    {

        #region Proriedades

        private JadlogApp objJadlogApp = new JadlogApp();
        private PedidoProtheusApp objPedidoProtheusApp = new PedidoProtheusApp();
        private SkyhubApp objSkyhubApp = new SkyhubApp();

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

        
        private void button7_Click_1(object sender, EventArgs e)
        {
            frmProdutoConsulta frm = new frmProdutoConsulta();
            frm.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //frmProdutoCadastro frm = new frmProdutoCadastro();
            //frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<PedidoProtheus> list = objPedidoProtheusApp.ListarPedidoPorDanfe(4);

            ///IMPORTANTE VERIFICAR TODAS AS CONSIDERAÇÕES EM OBSERVAÇÃO
            ///Importante campos de valores não podem conter vírgulas
            StreamWriter writer = new StreamWriter(@"C:\Users\administrador.TECHSHOP\Desktop\ArquivoPronto.txt");

            string CodigoArquivo = "000";
            string Remetente = list[0].RemetenteCnpj.PadRight(35);
            string Destinatario = list[0].DescricaoCliente.PadRight(35);
            string Dia = DateTime.Now.Day.ToString().PadLeft(2, '0');
            string Mes = DateTime.Now.Month.ToString().ToString().PadLeft(2, '0'); ;
            string Ano = DateTime.Now.Year.ToString().Substring(2);
            string hora = DateTime.Now.Hour.ToString().PadLeft(2, '0');
            string minuto = DateTime.Now.Minute.ToString().PadLeft(2, '0');
            string Segundo = DateTime.Now.Second.ToString();
            string Filler = "";
            Filler = Filler.PadLeft(145);

            writer.WriteLine(CodigoArquivo + Remetente + Destinatario + Dia + Mes + Ano + hora + minuto + "NOT" + Dia + Mes + hora + minuto + Segundo.PadLeft(2, '0').Substring(1, 1) + Filler);

            CodigoArquivo = "310";
            string Filler310 = "";
            Filler310 = Filler310.PadRight(223);
            writer.WriteLine(CodigoArquivo + "NOTFI" + Dia + Mes + hora + minuto + Segundo.PadLeft(2, '0').Substring(1, 1) + Filler310);

            CodigoArquivo = "311";
            string CgcEmbarcadora = list[0].RemetenteCnpj.PadRight(14);
            string InscricaoEstadual = list[0].RemetenteIe.PadRight(15);
            string EnderecoLogradoura = list[0].RemetenteEndereco.PadRight(40);
            string CidadeLogradoura = list[0].RemetenteCidade.PadRight(35);
            string CepLogradoura = list[0].RemetenteCep.Replace("-", "").PadRight(9);
            string EstadoLogradoura = list[0].RemetenteEstado.PadRight(9);
            string NomeEmpresa = "Techshop.com.br";
            NomeEmpresa = NomeEmpresa.PadRight(40);
            string FillerEmbarcadora = "";
            FillerEmbarcadora = FillerEmbarcadora.PadRight(67);
            writer.WriteLine(CodigoArquivo + CgcEmbarcadora + InscricaoEstadual + EnderecoLogradoura + CidadeLogradoura + CepLogradoura + EstadoLogradoura + Dia + Mes + DateTime.Now.Year + NomeEmpresa);

            CodigoArquivo = "312";
            string NomeDestinatario = list[0].DescricaoCliente.PadRight(40);
            string CnpjCpfDestinatario = list[0].DescricaoCPF.PadLeft(14,'0');
            string InscricaoEstadualDestinatario = "";
            InscricaoEstadualDestinatario = InscricaoEstadualDestinatario.PadRight(15);
            string Endereco = (list[0].DescricaoRua + "-" + list[0].DescricaoNumeroDestinatario).PadRight(40);
            string Bairro = list[0].DescricaoBairro.PadRight(20);
            string Cidade = list[0].DescricaoCidade.PadRight(35);
            string Cep = list[0].DescricaoCep.PadRight(9);
            string CodigoMunicipio = "";
            CodigoMunicipio = CodigoMunicipio.PadRight(9);
            string Estado = list[0].DescricaoRegiao.PadRight(9);
            string AreaFrete = "".PadRight(4);
            string Telefone = list[0].DescricaoTelefone1.Trim().PadRight(35);

            writer.WriteLine(CodigoArquivo + NomeDestinatario + CnpjCpfDestinatario + InscricaoEstadualDestinatario + Endereco + Bairro + Cidade + Cep + CodigoMunicipio + Estado + AreaFrete + Telefone);

            CodigoArquivo = "313";

            string CodigoRomaneio = "00001";
            CodigoRomaneio = CodigoRomaneio.PadRight(15);
            string CodigoRota = "";
            CodigoRota = CodigoRota.PadRight(7);
            string MeioTransporte = "0";
            string TipoTransporteCarga = "0";
            string TipoDeCarga = "0";
            string CondicaoFrete = "C";
            string SerieNotaFiscal = list[0].SerieNotaFiscal.PadRight(3);
            string NumeroNotaFiscal = list[0].NumeroNotaFiscal.PadLeft(9, '0');
            string DataEmissao = list[0].DataNotaFiscal.Day.ToString().PadLeft(2, '0') + list[0].DataNotaFiscal.Month.ToString().PadLeft(2, '0') + list[0].DataNotaFiscal.Year;
            string NaturezaMercadoria = "Eletrônicos";
            NaturezaMercadoria = NaturezaMercadoria.PadRight(15);
            string EspecieAcondicionamento = "Caixas";
            EspecieAcondicionamento = EspecieAcondicionamento.PadRight(15);

            /*~IMPORTANTE VERIFICAR COMO O PROTHEUS IRÁ ENVIAR ESTA INFORMAÇÃO
            CORRETO 0000100 = 1 VOLUME
            */
            string QtdeVolumes = "0000100";
            //string QtdeVolumes = list[0].Volumes.Replace(",","").Replace(".","").PadLeft(7, '0');
            string ValorNotaFiscal = list[0].ValorDeclaradoNota.Replace(",", "").Replace(".", "").PadLeft(15, '0');
            /*~IMPORTANTE VERIFICAR COMO O PROTHEUS IRÁ ENVIAR ESTA INFORMAÇÃO
             CORRETO 0000100 = 1 KG
             */
            string PesoTotalMercadoria = "0000100";
            //string PesoTotalMercadoria = list[0].PesoReal.Replace(",", "").Replace(".", "").PadLeft(7, '0');
            string Cubagem = "00000";
            string TipoIcms = "S";
            string SeguroEfetuado = "N";
            string ValorSeguro = "000000000000000";
            string ValorSerCobrado = "000000000000000";
            string NumeroPlaca = "       ";
            string PlanoCargaRapida = " ";
            string ValorFrete ="000000000000000";
            string ValorAdValorem = "000000000000000";
            string ValorTotalTaxas = "000000000000000";
            string ValorTotalFrete = "000000000000000";
            string AcaoDocumento = "I";
            string ValorIcms = "000000000000";
            string ValorIcmsRetido = "000000000000";
            string IndicacaoBonificacao = "N";
            string Filler313 = "  ";
            string Danfe = list[0].Danfe;

            writer.WriteLine(CodigoArquivo + CodigoRomaneio + CodigoRota + MeioTransporte + TipoTransporteCarga + TipoDeCarga + CondicaoFrete + SerieNotaFiscal + NumeroNotaFiscal + DataEmissao + NaturezaMercadoria + EspecieAcondicionamento + QtdeVolumes + ValorNotaFiscal + PesoTotalMercadoria+ Cubagem+TipoIcms+ SeguroEfetuado+ ValorSeguro+ ValorSerCobrado+ NumeroPlaca+ PlanoCargaRapida+ ValorFrete+ ValorAdValorem+ ValorTotalTaxas+ ValorTotalFrete+ AcaoDocumento+ ValorIcms+ ValorIcmsRetido+ IndicacaoBonificacao+ Filler313+ Danfe);

            CodigoArquivo = "318";

            string ValorTotalDasNotas = "000000000000000";
            string PesoTotalNotas = "000000000000000";
            string PesoTotalDensidadeCubagem = "000000000000000";
            string QuantidadeTotalVolumes = "000000000000000";
            string ValoraSerCobrado = "000000000000000";
            string ValorTotalSeguro = "000000000000000";

            writer.WriteLine(CodigoArquivo+ ValorTotalDasNotas+ PesoTotalNotas+ PesoTotalDensidadeCubagem+QuantidadeTotalVolumes+ ValoraSerCobrado+ ValorTotalSeguro);

            writer.Close();
            writer.Dispose();

            MessageBox.Show("Arquivo Gerado com Sucesso!");

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                // objPedidoProtheusApp.AlteraStatusPedido(6, 7);

                objJadlogApp.AtualizarInformacaoPedidoTransportadora();

                MessageBox.Show("Pedidos Importados para o Protheus com Sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                objPedidoProtheusApp.AlteraStatusPedido(1, 2);

                MessageBox.Show("Pedidos Importados para o Protheus com Sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                objPedidoProtheusApp.AlteraStatusPedido(2, 3);
                MessageBox.Show("Pedidos Faturados com Sucesso.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                objSkyhubApp.InformarPedidoEnviadoSkyhub();

                MessageBox.Show("Informações enviadas skyhub com sucesso!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btnCriacaoPedidoSkyhub_Click(object sender, EventArgs e)
        {

            try
            {
                frmCadastroPedidosSkyhub frm = new frmCadastroPedidosSkyhub();
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);

            }
        }

        private void btnAlteraStatusPedidoSkyhub_Click(object sender, EventArgs e)
        {
            frmAlteracaoStatusPedidoSkyhub frmAlteracaoPedidos = new frmAlteracaoStatusPedidoSkyhub();
            frmAlteracaoPedidos.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                MessageBox.Show("Solução não Implementada");

            }
            catch (Exception ex)
            {


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var newInvoice = new Invoice { key = "31161108351293000163550010002091271001645457" };
            var newShipment = new Shipment
            {
                code = DateTime.Now.ToString("yyyyMMddHHmmss"),
                track = new ShipmentTrack { carrier = "JADLOG", method = "Expresso", code = "JAD12345678" }
            };

            ResultProcessing obj = new OrderApp().PostShipment("Americanas-1487187821428", newShipment, newInvoice);

            string teste = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmRetiraPedidoFila frm = new frmRetiraPedidoFila();
            frm.ShowDialog();
        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCancelaPedidoJadLog obj = new frmCancelaPedidoJadLog();
            obj.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            objJadlogApp.EnviarInformacoesTransportadora(1);

        }
        private void btnImportPedidosSkyhub_Click(object sender, EventArgs e)
        {
            try { 
                  PedidosApp objApp = new PedidosApp();
              

                string mensagem = objApp.IncluirPedidosBaseEspelhoSkyhub();

                if (mensagem == "")
                {
                    MessageBox.Show("Processamento realizado, gentileza  conferir tabela de pedidos e log de erro!");

                }
                else{

                    MessageBox.Show(mensagem);

              
                }

                
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

                PedidoProtheusApp objApp = new PedidoProtheusApp();
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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                PedidoProtheusApp objApp = new PedidoProtheusApp();
                

                MessageBox.Show(objApp.IncluirPedidosBaseEspelhoProtheus());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message);

            }
        }



        private void button13_Click(object sender, EventArgs e)
        {

            try
            {
                objSkyhubApp.InformarPedidosEntregueSkyhub();

                MessageBox.Show("Informações enviadas skyhub com sucesso!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog salvar = new SaveFileDialog();// novo
                
                Excel.Application App; // Aplicação Excel
                Excel.Workbook WorkBook; // Pasta
                Excel.Worksheet WorkSheet; // Planilha
                object misValue = System.Reflection.Missing.Value;

                App = new Excel.Application();
                WorkBook = App.Workbooks.Add(misValue);
                WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;

                // passa as celulas do DataGridView para a Pasta do Excel
                for (i = 0; i <= 20 - 1; i++)
                {
                    for (j = 0; j <= 10 - 1; j++)
                    {
                        
                        WorkSheet.Cells[i + 1, j + 1] = "10";
                    }
                }

                // define algumas propriedades da caixa salvar
                salvar.Title = "Exportar para Excel";
                salvar.Filter = "Arquivo do Excel *.xls | *.xls";
                salvar.ShowDialog(); // mostra

                // salva o arquivo
                WorkBook.SaveAs(salvar.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,

                Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                WorkBook.Close(true, misValue, misValue);
                App.Quit(); // encerra o excel

                MessageBox.Show("Exportado com sucesso!");





            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }

        }

        #endregion

        private void button15_Click(object sender, EventArgs e)
        {
            try { 

                objPedidoProtheusApp.AlteraStatusPedido(1, 4);
                MessageBox.Show("Pedidos Faturados com Sucesso.");

              }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
         }
    }
        
}
                                               