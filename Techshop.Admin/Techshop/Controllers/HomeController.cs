using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Techshop.Util;
using Techshop.Aplication;

namespace REF_RezendeERPFinanceiro.Controllers
{
  // [Authorize]
    public class HomeController : Controller
    {
        #region Propriedades
                 
        public int CodigoUsuario = VariaveisGlobais.CodigoUsuario;
        private AppUsuario objAppUsuario = new AppUsuario();

        #endregion

        #region Retorna Menu
        [HttpGet]
        public JsonResult RetornaMenu(int CodigoEmpresa)
        { 

            try
            {
                //BDMenu objBdMenu = new BDMenu();

                return Json(null);

            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }
        
        public ActionResult Menu()
        {
            //BDMenu objBdMenu = new BDMenu();
           // ViewBag.Menu= objBdMenu.Listar(1);
            return PartialView();
        }
        #endregion

        #region Erro


        public ActionResult PaginaNaoExiste()
        {
            try
            {
                Util.SistemaPublicidade.VariaveisGlobais.CodigoEmpresa = 1;
                Util.SistemaPublicidade.VariaveisGlobais.CodigoUsuario = 1;

               // BDMenu objBdMenu = new BDMenu();
               // ViewData["Menu"] = objBdMenu.Listar(1, 1);
                return View();
            }
            catch (Exception ex)
            {
                return View(); 

            }
        }

        #endregion

        #region Index
        public ActionResult Index()
        {
            try
            {
                TempData["DadosUsuario"] = objAppUsuario.Listar(CodigoUsuario);
                TempData.Keep();

                return View();
            }
            catch (Exception ex)
            {
                return View(); 

            }
        }
        #endregion
    }
}
