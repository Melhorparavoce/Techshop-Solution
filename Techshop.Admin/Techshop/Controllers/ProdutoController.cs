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
using SkyHubAdapter.Domain.SkyHub;

namespace REF_RezendeERPFinanceiro.Controllers
{  
    //[Authorize]
    public class ProdutoController : Controller
    {

        #region Propriedades

        Product entidadeProduct = new Product();
        ProdutoApp objProdutoApp = new ProdutoApp();
        CategoriasApp objCategoriasApp = new CategoriasApp();
        LogerroApp objLogerroApp = new LogerroApp();

        #endregion

        #region Busca

        [HttpGet]
        public JsonResult Buscar(string Nome,string sku,int QuantidadeMinima,int QuantidadeMaxima,string Status,int TotalPaginas,int PaginaAtual)
        {
            try
            {
                List<Product> list = objProdutoApp.Listar(PaginaAtual, TotalPaginas,sku, Nome, QuantidadeMinima, QuantidadeMaxima, Status);
                

                return Json(list, JsonRequestBehavior.AllowGet);
                
                
            }
            catch (Exception ex)
            {
                return Json("Erro ao buscar registro" + ex.Message);
            }

        }

        [HttpGet]
        public JsonResult BuscarCategorias()
        {
            try
            {
                List<Categoria> list = objCategoriasApp.Listar();
                return Json(list, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json("Erro ao buscar registro" + ex.Message);
            }

        }

        [HttpGet]
        public JsonResult BuscarSubCategorias(int CodigoCategoria)
        {
            try
            {
                List<SubCategoria> list = objCategoriasApp.ListarSubCategoriasPorCodigoCategoria(CodigoCategoria);
                return Json(list, JsonRequestBehavior.AllowGet);


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

            List<Product> list = new List<Product>();
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(FormCollection objFormCollection)
        {
            try
            {
                List<Product> list = null;// objProdutoApp.Listar(objFormCollection["Sku"].ToString().Trim(), objFormCollection["Nome"].ToString().Trim(), Convert.ToInt32(objFormCollection["EstoqueDe"].ToString().Trim()), Convert.ToInt32(objFormCollection["EstoqueAte"].ToString().Trim()), objFormCollection["Status"]);

                return View(list);
            }
            catch (Exception ex)
            {
                return View();

            }
        }

        #endregion
        
        #region Create
        [HttpGet]
        public ActionResult Create()
        {

            Product objCreate = new Product();
            return View(objCreate);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Product objProduct,FormCollection formCollection)
        {
            try
            {
                

                #region Envio de Imagens
                    List<string>  listImagens = new List<string>();

                if(formCollection["Foto1"]!="")
                    listImagens.Add(formCollection["Foto1"]);
                if (formCollection["Foto2"] != "")
                    listImagens.Add(formCollection["Foto2"]);
                if (formCollection["Foto3"] != "")
                    listImagens.Add(formCollection["Foto3"]);
                if (formCollection["Foto4"] != "")
                    listImagens.Add(formCollection["Foto4"]);
                if (formCollection["Foto5"] != "")
                    listImagens.Add(formCollection["Foto5"]);
                if (formCollection["Foto6"] != "")
                    listImagens.Add(formCollection["Foto6"]);

                #endregion

                #region Variações de Produto
                List<Specification> listEspecificacoes = new List<Specification>();
                List<Variation> listVariacoes = new List<Variation>();
                List<string> ListVariacaoAtributos = new List<string>();

                int Variacoes = 1;

                for (int i = 0; i < formCollection.Count; i++)
                {

                    if (formCollection.Keys[i] == "Sku"+ Variacoes.ToString())
                    {
                        Variation entidadeVariation = new Variation();
                        entidadeVariation.sku = formCollection["Sku"+Variacoes];
                        entidadeVariation.ean = formCollection["ean" + Variacoes];
                        entidadeVariation.qty = Convert.ToInt32(formCollection["qty" + Variacoes]);
                        List<string> listImagensVariacao = new List<string>();

                        if(formCollection["ImagemVariacaoFoto1" + Variacoes].Trim() != "")
                           listImagensVariacao.Add(formCollection["ImagemVariacaoFoto1" + Variacoes]);
                        if (formCollection["ImagemVariacaoFoto2" + Variacoes].Trim() != "")
                            listImagensVariacao.Add(formCollection["ImagemVariacaoFoto2" + Variacoes]);
                        if (formCollection["ImagemVariacaoFoto3" + Variacoes].Trim() != "")
                            listImagensVariacao.Add(formCollection["ImagemVariacaoFoto3" + Variacoes]);
                        if (formCollection["ImagemVariacaoFoto4" + Variacoes].Trim() != "")
                            listImagensVariacao.Add(formCollection["ImagemVariacaoFoto4" + Variacoes]);
                        if (formCollection["ImagemVariacaoFoto5" + Variacoes].Trim() != "")
                            listImagensVariacao.Add(formCollection["ImagemVariacaoFoto5" + Variacoes]);
                        if (formCollection["ImagemVariacaoFoto6" + Variacoes].Trim() != "")
                            listImagensVariacao.Add(formCollection["ImagemVariacaoFoto6" + Variacoes]);
                        
                        entidadeVariation.images = listImagensVariacao;

                        //ImagemVariacao

                        List<Specification> listEspecificaoesVariacoes = new List<Specification>();

                        if (formCollection["Cor" + Variacoes] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Cor";
                            entidadeSpecification.value = formCollection["Cor" + Variacoes];
                            listEspecificaoesVariacoes.Add(entidadeSpecification);
                          

                        }
                        if (formCollection["Tamanho" + Variacoes] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Tamanho";
                            entidadeSpecification.value = formCollection["Tamanho" + Variacoes];
                            listEspecificaoesVariacoes.Add(entidadeSpecification);
                           

                        }
                        if (formCollection["Voltagem" + Variacoes] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Voltagem";
                            entidadeSpecification.value = formCollection["Voltagem" + Variacoes];
                            listEspecificaoesVariacoes.Add(entidadeSpecification);
                           

                        }

                        entidadeVariation.specifications = listEspecificaoesVariacoes;
                        listVariacoes.Add(entidadeVariation);

                        

                        Variacoes++;
                    }

                   if(formCollection.Keys[i]== "Sku")
                    {
                        if (formCollection["Cor"] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Cor";
                            entidadeSpecification.value = formCollection["Cor"];
                            listEspecificacoes.Add(entidadeSpecification);

                            ListVariacaoAtributos.Add("Cor");

                        }
                        if (formCollection["Tamanho"] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Tamanho";
                            entidadeSpecification.value = formCollection["Tamanho"];
                            listEspecificacoes.Add(entidadeSpecification);

                            ListVariacaoAtributos.Add("Tamanho");
                        }
                        if (formCollection["Voltagem"] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Voltagem";
                            entidadeSpecification.value = formCollection["Voltagem"];
                            listEspecificacoes.Add(entidadeSpecification);

                            ListVariacaoAtributos.Add("Voltagem");
                        }
                        
                    }
                }


                #endregion 


                var retorno =  objProdutoApp.Gravar(ListVariacaoAtributos,listVariacoes,listEspecificacoes, objProduct, Convert.ToInt32(formCollection["SelectSubCategoria"]), listImagens);

                if (retorno.Success)
                {
                    ViewBag.Mensagem = "Produto Criado Na Skyhub com Sucesso!";

                }
                else
                {
                    ViewBag.Mensagem = "Erro ao Criar Produto na Skyhub, Mensagem: "+ retorno.Message;

                }


                Product objCreate = new Product();
                return View(objCreate);
                


            }
            catch (Exception ex)
            {
                objLogerroApp.GravarLogErro("Erro ao Criar Produto Skyhub", "Erro ao criar pedido skyhub controller", ex.Message);

                ViewBag.Mensagem = "Erro Ao Criar Produto Skyhub";

                return View();
            }
        }

        #endregion

        #region Edit


        [HttpGet]
        public ActionResult Edit(string id="")
        {
            try
            {
                ViewBag.Mensagem = "";
                return View(objProdutoApp.Listar(id));
                
            }
            catch (Exception ex)
            {
                objLogerroApp.GravarLogErro("Erro ao Buscar Produto Skyhub", "Erro ao buscar produto skyhub controller", ex.Message);

                ViewBag.Mensagem = "Erro o Buscar Produto Skyhub";

                return View();
             }

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Product objProduct, FormCollection formCollection)
        {
            try
            {
                #region Envio de Imagens
                List<string> listImagens = new List<string>();

                if (formCollection["Foto1"] != "")
                    listImagens.Add(formCollection["Foto1"]);
                if (formCollection["Foto2"] != "")
                    listImagens.Add(formCollection["Foto2"]);
                if (formCollection["Foto3"] != "")
                    listImagens.Add(formCollection["Foto3"]);
                if (formCollection["Foto4"] != "")
                    listImagens.Add(formCollection["Foto4"]);
                if (formCollection["Foto5"] != "")
                    listImagens.Add(formCollection["Foto5"]);
                if (formCollection["Foto6"] != "")
                    listImagens.Add(formCollection["Foto6"]);

                #endregion

                #region Variações de Produto
                List<Specification> listEspecificacoes = new List<Specification>();
                List<Variation> listVariacoes = new List<Variation>();
                List<string> ListVariacaoAtributos = new List<string>();

                int Variacoes = 1;

                for (int i = 0; i < formCollection.Count; i++)
                {

                    if (formCollection.Keys[i] == "Sku" + Variacoes.ToString())
                    {
                        Variation entidadeVariation = new Variation();
                        entidadeVariation.sku = formCollection["Sku" + Variacoes];
                        entidadeVariation.ean = formCollection["ean" + Variacoes];
                        entidadeVariation.qty = Convert.ToInt32(formCollection["qty" + Variacoes]);
                        List<Specification> listEspecificaoesVariacoes = new List<Specification>();

                        if (formCollection["Cor" + Variacoes] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Cor";
                            entidadeSpecification.value = formCollection["Cor" + Variacoes];
                            listEspecificaoesVariacoes.Add(entidadeSpecification);


                        }
                        if (formCollection["Tamanho" + Variacoes] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Tamanho";
                            entidadeSpecification.value = formCollection["Tamanho" + Variacoes];
                            listEspecificaoesVariacoes.Add(entidadeSpecification);


                        }
                        if (formCollection["Voltagem" + Variacoes] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Voltagem";
                            entidadeSpecification.value = formCollection["Voltagem" + Variacoes];
                            listEspecificaoesVariacoes.Add(entidadeSpecification);


                        }

                        entidadeVariation.specifications = listEspecificaoesVariacoes;
                        listVariacoes.Add(entidadeVariation);



                        Variacoes++;
                    }

                    if (formCollection.Keys[i] == "Sku")
                    {
                        if (formCollection["Cor"] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Cor";
                            entidadeSpecification.value = formCollection["Cor"];
                            listEspecificacoes.Add(entidadeSpecification);

                            ListVariacaoAtributos.Add("Cor");

                        }
                        if (formCollection["Tamanho"] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Tamanho";
                            entidadeSpecification.value = formCollection["Tamanho"];
                            listEspecificacoes.Add(entidadeSpecification);

                            ListVariacaoAtributos.Add("Tamanho");
                        }
                        if (formCollection["Voltagem"] != "")
                        {
                            Specification entidadeSpecification = new Specification();
                            entidadeSpecification.key = "Voltagem";
                            entidadeSpecification.value = formCollection["Voltagem"];
                            listEspecificacoes.Add(entidadeSpecification);

                            ListVariacaoAtributos.Add("Voltagem");
                        }

                    }
                }


                #endregion 


                var retorno = objProdutoApp.Atualizar(ListVariacaoAtributos, listVariacoes, listEspecificacoes, objProduct, Convert.ToInt32(formCollection["SelectSubCategoria"]), listImagens);

                if (retorno.Success)
                {
                    ViewBag.Mensagem = "Produto Atualizado com Sucesso!";

                }
                else
                {
                    ViewBag.Mensagem = "Erro ao Criar Atualizar na Skyhub, Mensagem: " + retorno.Message;

                }

                
                return View(objProdutoApp.Listar(objProduct.sku));

            }
            catch (Exception ex)
            {
                objLogerroApp.GravarLogErro("Erro ao Criar Produto Skyhub", "Erro ao criar pedido skyhub controller", ex.Message);

                ViewBag.Mensagem = "Erro Ao Criar Produto Skyhub";

                return View();
            }
        }


        #endregion

    }
}