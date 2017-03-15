using System.Collections.Generic;
using System.Web.Mvc;
using Techshop.Aplication;
using Techshop.Model;
using System;
using System.Web.UI.WebControls;
using System.Text;
using Microsoft.Office.Interop.Excel;
namespace REF_RezendeERPFinanceiro.Controllers
{
  //  [Authorize]
    public class ExpedicaoController : Controller
    {
        
        #region Propriedades

       // public int CodigoUsuario = VariaveisGlobais.CodigoUsuario;
        private AppUsuario objAppUsuario = new AppUsuario();
        private PedidoProtheusApp objPedidosProtheusApp = new PedidoProtheusApp();
        private PedidoProtheus EntidadePedidoProtheus = new PedidoProtheus();
        private JadlogApp objJadlogApp = new JadlogApp();
        private LogerroApp objLogerroApp = new LogerroApp();
        private RomaneioApp objRomaneioApp = new RomaneioApp();


        #endregion   

        #region Index
        [HttpGet]
        public ActionResult Index()
        {
            List<PedidoProtheus> retorno = objPedidosProtheusApp.ListarPedidoPorDanfe(4);

            TempData["DadosUsuario"] = objAppUsuario.Listar(2);
            TempData.Keep();

            return View(retorno);
        }


        #endregion

        #region Serialização
        //FechamentoLote
        [HttpPost]
        public ActionResult Index(FormCollection objFormCollection)
        {
            objPedidosProtheusApp.AtualizaStatusPedido(objFormCollection["Danfe"], 4);

             List<PedidoProtheus> retorno = objPedidosProtheusApp.ListarPedidoPorDanfe(4);

            TempData["DadosUsuario"] = objAppUsuario.Listar(2);
            TempData.Keep();

            return View(retorno);
        }
        #endregion

        #region Jadlog
        
    
        [HttpGet]
        public ActionResult Jadlog()
        {
               

             return View(objPedidosProtheusApp.ListarPedidoPorTransportadora(4, "Jadlog"));
          

        }
        [HttpPost]
        public ActionResult Jadlog(FormCollection objFormColection)
        {
            List<String> listaMensagens = new List<string>();
            try
            {
                string[] ArrayPedidos = objFormColection["CodigoPedido"].Split(',');
           
                foreach (string item in ArrayPedidos)
                {
                    listaMensagens.Add(objJadlogApp.EnviarInformacoesTransportadora(Convert.ToInt32(item)));
                }

                ViewData["Mensagem"] = listaMensagens; 

                 return View(objPedidosProtheusApp.ListarPedidoPorTransportadora(4, "Jadlog"));

            }catch(Exception ex)
            {
                objLogerroApp.GravarLogErro("Envio pedidos Jadlog", "Erro ao enviar pedidos Jadlog controller", ex.Message);
                listaMensagens.Add("Erro ao enviar pedidos Jadlog.Exceção:" + ex.Message);
                ViewData["Mensagem"] = listaMensagens; 
                return View(objPedidosProtheusApp.ListarPedidoPorTransportadora(4, "Jadlog"));
            }
        }

        #endregion         

        #region Outros Metodos
        [HttpPost]
        protected override void Dispose(bool disposing)
        {
            
            //db.Dispose();
            //base.Dispose(disposing);
        }

        #endregion      

        #region Fechamento Lote

        [HttpGet]
        public ActionResult FechamentoLote()
        {

            try
            { List<PedidoProtheus> list = new List<PedidoProtheus>();
                return View(list);


            }catch(Exception ex)
            {
                return View();

            }

                            
        }

        [HttpPost]
        public ActionResult FechamentoLote(FormCollection objFormColection,string Pesquisar,string Exportar,string Fechar)
        {                          
           try
            {
                
                
                
                DateTime DataInicio = AlteraFormatoDataMMddAAA(objFormColection["DataInicio"]);
                DateTime DataFim = AlteraFormatoDataMMddAAA(objFormColection["DataFim"]);
                ViewBag.DataInicio = objFormColection["DataInicio"];
                ViewBag.DataFim = objFormColection["DataFim"];
                ViewBag.Status = Request.Form["Status"];
                ViewBag.Nome = Request.Form["Cliente"];
                ViewBag.Empresa = Request.Form["Empresa"];


                //Buscar informações
                if (Pesquisar != null)
                {
                    if(Request.Form["Status"]=="Aberto")
                       return View(objRomaneioApp.Listar(0,4, DataInicio, DataFim, objFormColection["Empresa"], objFormColection["Cliente"]));
                    else
                        return View(objRomaneioApp.Listar(1, 4, DataInicio, DataFim, objFormColection["Empresa"], objFormColection["Cliente"]));

                }


                if (Fechar != null)
                {
                    return View(objRomaneioApp.FecharLote(objFormColection["CodigoPedido"].Split(',')));

                }


                if (Exportar != null)
                {      
                    GerarArquivoExcel(DataInicio,DataFim);
                    List<PedidoProtheus> list = new List<PedidoProtheus>();
                    return View(list);
                }

                
                //Exportar


                //Fechar


                //0dias



                return View();

            }
            catch (Exception ex)
            {
                return View();

            }
          
        }

        #endregion

        #region Outros Métodos
        public  DateTime AlteraFormatoDataMMddAAA(string Data)
        {

            string Dia = Data.Split('/')[0];
            string Mes = Data.Split('/')[1];
            string Ano = Data.Split('/')[2];

            return Convert.ToDateTime(Mes + "/" + Dia + "/" + Ano);

        }

        private void GerarArquivoExcel(DateTime DataInicio, DateTime DataFim)
        {
                      
            foreach (Romaneio item in objRomaneioApp.ListarRomaneiosPeriodo(DataInicio, DataFim))
            {
                string teste = "";

            }

            
            // Pesquisa Todos os Romaneios Salvos No Período

            /*


            Workbook workbook;
            Application objExcel;

            objExcel = new Application();
            objExcel.Visible = false;
            objExcel.DisplayAlerts = false;

            for (var i = 0; i < 5; i++)
            {
                workbook = objExcel.Workbooks.Add("Galo");
                var worksheet = (Worksheet)workbook.Worksheets.get_Item(i + 1);
                worksheet.Name = string.Format("test{0}", i + 1);

                worksheet.Cells[1, 1] = "Galo";
            }



            //oWB.SaveAs(fileName, XlFileFormat.xlOpenXMLWorkbook,"missing", "missing", "missing", "missing",
            //     XlSaveAsAccessMode.xlNoChange,
            //     "missing", ""missing, "missing", "missing", "missing");
            // oWB.Close(missing, missing, missing);
            // oXL.UserControl = true;
            // oXL.Quit();





            string teste = "";*/

        }

        #endregion

    }
}