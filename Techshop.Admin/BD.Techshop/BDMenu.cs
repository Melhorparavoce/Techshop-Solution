using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using Model.Techshop;
using System.Linq;


namespace BD.Techshop
{
    public class BDMenu
    {
       
       // SPREntities dc = new SPREntities();

        /*  public void Excluir(int Codigo)
          {

              SPR_MENU obj = (from p in dc.SPR_MENU.Where(p => (p.COD_MENU == Codigo)) select p).FirstOrDefault();  ///where p =>(p.COD_TENTATIVA == CodigoTentativa || p.COD_PERGUNTA = CodigoPergunta) select p).FirstOrDefault();

              dc.SPR_MENU.Remove(obj);
              dc.SaveChanges();    

          }

          public List<Menu> ListaPorEmpresa(int CodigoExame)
          {

              List<Menu> data = (from menu in dc.SPR_MENU
                                 where menu.COD_EXAME == CodigoExame
                                 select new Menu
                                 {
                                     CodigoMenu = menu.COD_MENU,
                                     CodigoExame = menu.COD_EXAME,
                                     CodigoNivel = menu.COD_NIVEL,
                                     DescricaoMenu = menu.DSC_MENU,
                                     IndicadorTipo = menu.IND_TIPO,
                                     DescricaoParametro1 = menu.DSC_PARAMETRO1,
                                     DescricaoParametro2 = menu.DSC_PARAMETRO2,
                                     QuantidadePerguntas = (menu.QTDE_PERGUNTAS ?? 0),
                                     CodigoEmpresa = (menu.COD_EMPRESA ?? 0),
                                     CodigoIdentificacao = (menu.COD_IDENTIFICACAO ?? 0)
                                 }).ToList<Menu>();

              return data;

          }

          public List<Menu> ListaMenuNivel(int CodigoExame, int CodigoNivel)
          {

             

              List<Menu> data = (from menu in dc.SPR_MENU
                                 where menu.COD_NIVEL == CodigoNivel && menu.COD_EXAME == CodigoExame
                                 select new Menu
                                 {
                                     CodigoMenu = menu.COD_MENU,
                                     CodigoExame = menu.COD_EXAME,
                                     CodigoNivel = menu.COD_NIVEL,
                                     DescricaoMenu = menu.DSC_MENU,
                                     IndicadorTipo = menu.IND_TIPO,
                                     DescricaoParametro1 = menu.DSC_PARAMETRO1,
                                     DescricaoParametro2 = menu.DSC_PARAMETRO2,
                                     QuantidadePerguntas = (menu.QTDE_PERGUNTAS ?? 0),
                                     CodigoEmpresa = (menu.COD_EMPRESA ?? 0),
                                     CodigoIdentificacao = (menu.COD_IDENTIFICACAO ?? 0)
                                 }).ToList<Menu>();  

              return data;
           }  
         /*
          public List<Menu> BuscarInformacoes(int CodigoEmpresa, string DescricaoExame)
          {

           

              List<Menu> data = (from menu in dc.SPR_MENU
                                 join exames in dc.SER_EXAME on menu.COD_EXAME equals exames.COD_EXAME
                                 where exames.DSC_EXAME.Contains(DescricaoExame) && exames.COD_EMPRESA == CodigoEmpresa
                                 orderby exames.DSC_EXAME,menu.COD_NIVEL,menu.DSC_MENU ascending
                                 select new Menu
                                 {
                                     CodigoMenu = menu.COD_MENU,
                                     CodigoExame = menu.COD_EXAME,
                                     CodigoNivel = menu.COD_NIVEL,
                                     DescricaoMenu = menu.DSC_MENU,
                                     IndicadorTipo = menu.IND_TIPO,
                                     DescricaoParametro1 = (menu.DSC_PARAMETRO1?? ""),
                                     DescricaoParametro2 = (menu.DSC_PARAMETRO2?? ""),
                                     QuantidadePerguntas = (menu.QTDE_PERGUNTAS ?? 0),
                                     CodigoEmpresa = (menu.COD_EMPRESA ?? 0),
                                     CodigoIdentificacao = (menu.COD_IDENTIFICACAO ?? 0),
                                     DescricaoExame= exames.DSC_EXAME
                                 }).ToList<Menu>();

              return data;
          }
      

          public List<Menu> ListaInformacoesInterfacePricipal(int CodigoEmpresa, string DescricaoMenu)
          {

    

              List<Menu> data = (from menu in dc.SPR_MENU
                                 join exames in dc.SER_EXAME on menu.COD_EXAME equals exames.COD_EXAME
                                 where menu.DSC_MENU.Contains(DescricaoMenu) && exames.COD_EMPRESA == CodigoEmpresa
                                 orderby exames.DSC_EXAME, menu.COD_NIVEL, menu.DSC_MENU ascending
                                 select new Menu
                                 {
                                     CodigoMenu = menu.COD_MENU,
                                     CodigoExame = menu.COD_EXAME,
                                     CodigoNivel = menu.COD_NIVEL,
                                     DescricaoMenu = menu.DSC_MENU,
                                     IndicadorTipo = menu.IND_TIPO,
                                     DescricaoParametro1 = (menu.DSC_PARAMETRO1 ?? ""),
                                     DescricaoParametro2 = (menu.DSC_PARAMETRO2 ?? ""),
                                     QuantidadePerguntas = (menu.QTDE_PERGUNTAS ?? 0),
                                     CodigoEmpresa = (menu.COD_EMPRESA ?? 0),
                                     CodigoIdentificacao = (menu.COD_IDENTIFICACAO ?? 0),
                                     DescricaoExame = exames.DSC_EXAME
                                 }).ToList<Menu>();

              return data;
          }


          public List<Menu> ListaCodigoIdentificao(int CodigoIdentificacao,int CodigoEmpresa)
          {

         

              List<Menu> data = (from menu in dc.SPR_MENU
                                 where menu.COD_IDENTIFICACAO == CodigoIdentificacao && menu.COD_EMPRESA == CodigoEmpresa
                                 orderby menu.COD_NIVEL ascending
                                 select new Menu
                                 {
                                     CodigoMenu = menu.COD_MENU,
                                     CodigoExame = menu.COD_EXAME,
                                     CodigoNivel = menu.COD_NIVEL,
                                     DescricaoMenu = menu.DSC_MENU,
                                     IndicadorTipo = menu.IND_TIPO,
                                     DescricaoParametro1 = menu.DSC_PARAMETRO1,
                                     DescricaoParametro2 = menu.DSC_PARAMETRO2,
                                     QuantidadePerguntas = (menu.QTDE_PERGUNTAS ?? 0),
                                     CodigoEmpresa = (menu.COD_EMPRESA ?? 0),
                                     CodigoIdentificacao = (menu.COD_IDENTIFICACAO ?? 0)
                                 }).ToList<Menu>();

              return data;
          }

          public List<Menu> ListaMenuNivel2(int CodigoExame, int CodigoIdentificacao)
          {

       

              List<Menu> data = (from menu in dc.SPR_MENU
                                 where menu.COD_NIVEL == 2 && menu.COD_EXAME == CodigoExame && menu.COD_IDENTIFICACAO == CodigoIdentificacao
                                 select new Menu
                                 {
                                     CodigoMenu = menu.COD_MENU,
                                     CodigoExame = menu.COD_EXAME,
                                     CodigoNivel = menu.COD_NIVEL,
                                     DescricaoMenu = menu.DSC_MENU,
                                     IndicadorTipo = menu.IND_TIPO,
                                     DescricaoParametro1 = menu.DSC_PARAMETRO1,
                                     DescricaoParametro2 = menu.DSC_PARAMETRO2,
                                     QuantidadePerguntas = (menu.QTDE_PERGUNTAS ?? 0),
                                     CodigoEmpresa = (menu.COD_EMPRESA ?? 0),
                                     CodigoIdentificacao = (menu.COD_IDENTIFICACAO ?? 0)
                                 }).ToList<Menu>();

              return data;
          }
         
          public int ListaUltimoRegistro(int CodigoEmpresa)
          {
              int total = dc.SPR_MENU.Count();


              if (total == 0)
              {
                  return 1;
              }
              else
              {
                  var UtimoRegistro = (from d in dc.SPR_MENU where (d.COD_EMPRESA == CodigoEmpresa) select d.COD_MENU).Max();
                  return System.Convert.ToInt32(UtimoRegistro)+1;
              }

          }

          public void Incluir(Menu model)
          {              
              SPR_MENU objEntidade = new SPR_MENU();

              objEntidade.COD_IDENTIFICACAO = model.CodigoIdentificacao;
              objEntidade.COD_EMPRESA = model.CodigoEmpresa;
              objEntidade.COD_NIVEL = model.CodigoNivel;
              objEntidade.DSC_MENU = model.DescricaoMenu;
              objEntidade.DSC_PARAMETRO1 = (model.DescricaoParametro1 ?? "");
              objEntidade.DSC_PARAMETRO2 = (model.DescricaoParametro2 ?? "");
              objEntidade.QTDE_PERGUNTAS = model.QuantidadePerguntas;
              objEntidade.COD_EXAME = model.CodigoExame;
              objEntidade.IND_TIPO = model.IndicadorTipo;
              objEntidade.COD_NIVEL_SUPERIOR = model.CodigoNivelSuperior;
              dc.SPR_MENU.Add(objEntidade);
              dc.SaveChanges();

          }

          public List<Menu> ListarExame(int Codigo)
          {

       

              List<Menu> data = (from menu in dc.SPR_MENU
                                 where menu.COD_EXAME == Codigo
                                 select new Menu
                                 {
                                     CodigoMenu = menu.COD_MENU,
                                     CodigoExame = menu.COD_EXAME,
                                     CodigoNivel = menu.COD_NIVEL,
                                     DescricaoMenu = menu.DSC_MENU,
                                     IndicadorTipo = menu.IND_TIPO,
                                     DescricaoParametro1 = menu.DSC_PARAMETRO1,
                                     DescricaoParametro2 = menu.DSC_PARAMETRO2,
                                     QuantidadePerguntas = (menu.QTDE_PERGUNTAS ?? 0),
                                     CodigoEmpresa = (menu.COD_EMPRESA ?? 0)
                               
                                 }).ToList<Menu>();


              return data;
          }

          public List<Menu> ListarCodigo(int Codigo,int CodigoEmpresa)
          {

           
              List<Menu> data = (from menu in dc.SPR_MENU
                                 join ex in dc.SER_EXAME on menu.COD_EXAME equals ex.COD_EXAME
                                 where menu.COD_MENU == Codigo && menu.COD_EMPRESA == CodigoEmpresa
                                 orderby menu.COD_MENU ascending
                                 select new Menu
                                 {
                                     CodigoMenu = menu.COD_MENU,
                                     CodigoExame = menu.COD_EXAME,
                                     CodigoNivel = menu.COD_NIVEL,
                                     DescricaoMenu = menu.DSC_MENU,
                                     IndicadorTipo = menu.IND_TIPO,
                                     DescricaoParametro1 = (menu.DSC_PARAMETRO1?? ""),
                                     DescricaoParametro2 = (menu.DSC_PARAMETRO2 ?? ""),
                                     QuantidadePerguntas = (menu.QTDE_PERGUNTAS ?? 0),
                                     CodigoEmpresa = (menu.COD_EMPRESA ?? 0),
                                     DescricaoExame = ex.DSC_EXAME,
                                     CodigoIdentificacao = (menu.COD_IDENTIFICACAO??0)
                                 }).ToList<Menu>();


              return data;
          }
            
          public List<Menu> Listar(int Codigo,int CodigoUsuario)
          {

            
              List<Menu> data = (from menu in dc.SPR_MENU
                                 join ex in dc.SER_EXAME on menu.COD_EXAME equals ex.COD_EXAME
                                 join perm in dc.SER_USUARIO_EXAME on menu.COD_EXAME equals perm.COD_EXAME
                                 where menu.COD_EMPRESA == Codigo && perm.COD_USUARIO == CodigoUsuario
                                 orderby menu.COD_MENU ascending
                                 select new Menu
                                 {
                                     CodigoMenu = menu.COD_MENU,
                                     CodigoExame = menu.COD_EXAME,
                                     CodigoNivel = menu.COD_NIVEL,
                                     DescricaoMenu = menu.DSC_MENU,
                                     IndicadorTipo = menu.IND_TIPO,
                                     CodigoNivelSuperior = menu.COD_NIVEL_SUPERIOR,
                                     DescricaoParametro1 = (menu.DSC_PARAMETRO1 ?? ""),
                                     DescricaoParametro2 = (menu.DSC_PARAMETRO2 ?? ""),
                                     QuantidadePerguntas = (menu.QTDE_PERGUNTAS ?? 0),
                                     CodigoEmpresa = (menu.COD_EMPRESA ?? 0),
                                     CodigoIdentificacao = (menu.COD_IDENTIFICACAO ?? 0),
                                     DescricaoExame = ex.DSC_EXAME
                                 }).Distinct().ToList<Menu>();


              return data;
          }


             */

    }
}