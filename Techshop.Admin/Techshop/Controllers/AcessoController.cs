using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Security;
using System.Web.Mvc;
using Techshop.Aplication;
using Techshop.Model;
using Techshop.Util;
namespace REF_RezendeERPFinanceiro.Controllers
{  
    //[Authorize]
    public class AcessoController : Controller
    {

        #region Propriedades

        AppUsuario objAppUsuario = new AppUsuario();

        #endregion

        #region Login
        [HttpPost]
        public ActionResult Login(int CodigoMenu = 0, int CodigoTentativa = 0)
        {

            try
            {

                List<Usuario> list = objAppUsuario.Listar(Request.Form["username"], Request.Form["pwd"]);

              if (list.Count>0)
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(list[0].DescricaoLogin + list[0].DescricaoSenha, false);

                    VariaveisGlobais.CodigoUsuario = list[0].CodigoUsuario;
                 

                    Response.Redirect("/Home/index/");
                }else
                {  

                ViewBag.Erro = "Usuário ou senha inválidos";
                }

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex;
                return View();
            }

        }
     
        [HttpGet]
        public ActionResult Login()
        {
            Usuario obj = new Usuario();
            return View(obj);
        }    

        #endregion

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            base.Dispose(disposing);
        }
    }
}