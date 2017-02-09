using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Util.SistemaPublicidade;
using Techshop.Util;
using Techshop.Model;

namespace REF_RezendeERPFinanceiro.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        
        #region Propriedades

        public int CodigoEmpresa = Util.SistemaPublicidade.VariaveisGlobais.CodigoEmpresa;
        public int CodigoUsuario = Util.SistemaPublicidade.VariaveisGlobais.CodigoUsuario;
        //BD.Techshop.TechshopEntities1 db = new TechshopEntities1();

        #endregion

        #region Carregamento de Select
        [HttpGet]
        public JsonResult RetornaExames(int CodigoEmpresa)
        {
            try
            {
               
                 return Json(null, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }

        [HttpGet]
        public JsonResult RetornaParametroExame(int CodigoExame = 0)
        {
            try
            {
                           
                return Json(null, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }

        [HttpGet]
        public JsonResult RetornaConteudoParametro(int CodigoParametro = 0)
        {
            try
            {
               // BDConteudoParametros obj = new BDConteudoParametros();

                return Json(null, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }

        [HttpGet]
        public JsonResult CarregaComboExame(int CodigoUsuario)
        {
            try
            {
                //BDExame obj = new BDExame();

                return Json(null, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }
        [HttpGet]
        public JsonResult CarregaComboExameAluno(int CodigoAluno)
        {
            try
            {
                //BOExame objBOExame = new BOExame();

                return Json(null, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }
                                   
        #endregion

        #region Criação

        [HttpPost]
        public JsonResult Create(Usuario obj)
        {
            try
            {
                /*BOUsuarios objBoUsuario = new BOUsuarios();

                obj.DataExpiracao = Convert.ToDateTime(Datas.AlteraFormatoDataMMddAAA(obj.DataExpiracaoString));
                obj.CodigoEmpresa = CodigoEmpresa;

                objBoUsuario.GravarUsuario(obj);   */
                       
                return Json("Registro Adicionado Com Sucesso");

            }
            catch (Exception ex)
            {
                return Json("Erro:" + ex);
            }
        }

        public ActionResult Create()
        {
            try
            {
                //Usuarios Entidade = new Usuarios();
                //BDMenu objBdMenu = new BDMenu();
                //BOMenu objBoMenu = new BOMenu();
                //BOUsuarios objBoUsuarios = new BOUsuarios();
                //ViewData["Menu"] = objBdMenu.Listar(CodigoEmpresa, CodigoUsuario);
                //ViewData["MenuAdministrador"] = objBoMenu.RetornaMenuAdministrador(CodigoUsuario, CodigoEmpresa);
                //ViewData["DadosUsuario"] = objBoUsuarios.Listar(CodigoUsuario);

                //return View(Entidade);
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View();
            }
        }

        #endregion

        #region Busca

        [HttpGet]
        public JsonResult Busca(string DescricaoUsuario)
        {
            try
            {
                // BDUsuario objBdUsuario = new BDUsuario ();

                // return Json(objBdUsuario.Listar(DescricaoUsuario), JsonRequestBehavior.AllowGet);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Erro ao buscar registro" + ex.Message);
            }

        }
        #endregion

        #region Index
        [HttpGet]
        public ActionResult Index()
        {
           
            //BDMenu objBdMenu = new BDMenu();
            //BOMenu objBoMenu = new BOMenu();
            //BOUsuarios objBoUsuarios = new BOUsuarios();
            ////ViewData["Menu"] = objBdMenu.Listar(CodigoEmpresa, CodigoUsuario);
            //ViewData["MenuAdministrador"] = objBoMenu.RetornaMenuAdministrador(CodigoUsuario, CodigoEmpresa);
            ////ViewData["DadosUsuario"] = objBoUsuarios.Listar(CodigoUsuario);

            return View();
        }
        #endregion

        #region Atualização

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            try
            {
                //BOUsuarios objboUsuario = new BOUsuarios();
                //List<Usuarios> list = objboUsuario.Listar(id);
                //BDMenu objBdMenu = new BDMenu();
                //BOMenu objBoMenu = new BOMenu();
                //BOUsuarios objBoUsuarios = new BOUsuarios();
                ////ViewData["Menu"] = objBdMenu.Listar(CodigoEmpresa, CodigoUsuario);
                ////ViewData["MenuAdministrador"] = objBoMenu.RetornaMenuAdministrador(CodigoUsuario, CodigoEmpresa);
                ////ViewData["DadosUsuario"] = objBoUsuarios.Listar(CodigoUsuario);

                //list[0].DataExpiracaoString = Datas.AlteraFormatoDataddMMaaaa(list[0].DataExpiracao.ToShortDateString());


                //return View(list[0]);

                return View();

            }
            catch (Exception ex)
            {
                return Json("Erro:" + ex);
            }
        }

        [HttpPost]
        public JsonResult Edit(Usuario obj)
        {
            try
            {
                //BOUsuarios ObjBdUsuario = new BOUsuarios();
                //obj.DataExpiracao = Convert.ToDateTime(Datas.AlteraFormatoDataMMddAAA(obj.DataExpiracaoString));
             
                //obj.CodigoEmpresa = CodigoEmpresa;

                //ObjBdUsuario.Atualizar(obj);

                return Json("Registro Atualizado Com Sucesso");

            }
            catch (Exception ex)
            {
                return Json("Erro:" + ex);
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

        #region Exclusão

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                //BDUsuario obj = new BDUsuario();
                //obj.Excluir(id);

                return Json("Registros Excluídos Com Sucesso.", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json("Erro:" + ex);
            }

        }
        #endregion
    }
}