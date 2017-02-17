using System.Collections.Generic;
using System.Web.Mvc;
using Techshop.Aplication;
using Techshop.Model;
using System;
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
     
    }
}