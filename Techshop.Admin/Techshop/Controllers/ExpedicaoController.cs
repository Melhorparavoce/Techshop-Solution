using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Techshop.Util;
using Techshop.Aplication;

namespace REF_RezendeERPFinanceiro.Controllers
{
  //  [Authorize]
    public class ExpedicaoController : Controller
    {
        
        #region Propriedades

       // public int CodigoUsuario = VariaveisGlobais.CodigoUsuario;
        private AppUsuario objAppUsuario = new AppUsuario();

        #endregion


        #region Index
        [HttpGet]
        public ActionResult Index()
        {

            TempData["DadosUsuario"] = objAppUsuario.Listar(2);
            TempData.Keep();

            return View();
        }

        [HttpPost]
        public ActionResult AdicionarPedido(FormCollection objFormCollection)
        {

            //objFormCollection["Danfe"]

            TempData["DadosUsuario"] = objAppUsuario.Listar(2);
            TempData.Keep();

            return View();
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