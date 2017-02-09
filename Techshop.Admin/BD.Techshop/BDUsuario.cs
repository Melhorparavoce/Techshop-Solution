using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using Model.Techshop;
using System.Linq;

namespace BD.Techshop
{
    public class BDUsuario
    {

        TechshopEntities1 Context = new TechshopEntities1();



       // SPREntities dc = new SPREntities();
        
       /* public void RegistrarLog(string usuario)
        {
            SER_LOG objLog = new SER_LOG();
            objLog.DSC_USUARIO = usuario;
            objLog.DTA_HORA_LOG = System.DateTime.Now;

            dc.SER_LOG.Add(objLog);
            dc.SaveChanges();


        } */

        public List<Usuarios> Listar(string login, string senha)
        {
            List<Usuarios> data = (from usu in Context.TEC_USUARIO
                                   where usu.DSC_LOGIN == login && usu.DSC_SENHA == senha
                                select new Usuarios
                               {
                                    CodigoUsuario = usu.COD_USUARIO,
                                    DescricaoUsuario=usu.DSC_USUARIO,
                                    DescricaoEmail=usu.DSC_EMAIL, 
                                    DescricaoLogin=usu.DSC_LOGIN, 
                                    DescricaoSenha=usu.DSC_SENHA, 
                                    CodigoEmpresa=usu.COD_EMPRESA, 
                                    DataCadastro=usu.DTA_CADASTRO, 
                                    CodigoPerfil=usu.COD_PERFIL, 
                                    DataExpiracao=usu.DTA_EXPIRACAO, 
                                    IndicadorAtivo=usu.IND_ATIVO 
                               }).ToList<Usuarios>();

            return data;
        }
           
       /* public List<Usuarios> ListarPermissoesExame(int CodigoUsuario, int CodigoExame)
        {
            List<Usuarios> data = (from usu in Context.SPR_USUARIO_EXAME
                                   where usu.COD_USUARIO == CodigoUsuario && usu.COD_EXAME == CodigoExame
                                   select new Usuarios
                                   {
                                       CodigoUsuario = usu.COD_USUARIO,
                                    
                                      
                                   }).ToList<Usuarios>();

            return data;
        } */ 
              
        public List<Usuarios> ListarPermissoes(int CodigoUsuario, int CodigoEmpresa)
        {
            List<Usuarios> data = (from usu in Context.TEC_USUARIO
                                   where usu.COD_USUARIO == CodigoUsuario
                                   select new Usuarios
                                   {
                                       CodigoUsuario = usu.COD_USUARIO,
                                       DescricaoUsuario = usu.DSC_USUARIO,
                                       DescricaoEmail = usu.DSC_EMAIL,
                                       DescricaoLogin = usu.DSC_LOGIN,
                                       DescricaoSenha = usu.DSC_SENHA,
                                       CodigoEmpresa = usu.COD_EMPRESA,
                                       DataCadastro = usu.DTA_CADASTRO,
                                       CodigoPerfil = usu.COD_PERFIL,
                                       DataExpiracao = usu.DTA_EXPIRACAO,
                                       IndicadorAtivo = usu.IND_ATIVO
                                   }).ToList<Usuarios>();

            return data;
        }  

        public static TEC_USUARIO GetUsuarioLogado()
        {


            return null;
        }
                           
       /* public void InserirUsuarioExame(int CodigoUsuario, int CodigoExame)
        {
            SPR_USUARIO_EXAME objEntidade = new SPR_USUARIO_EXAME();

            objEntidade.COD_EXAME = CodigoExame;
            objEntidade.COD_USUARIO = CodigoUsuario;
            dc.SPR_USUARIO_EXAME.Add(objEntidade);
            dc.SaveChanges();

        }  
              */
                 
        public int Incluir(Usuarios model)
        {

            TEC_USUARIO objEntidade = new TEC_USUARIO();
            objEntidade.COD_EMPRESA = model.CodigoEmpresa;
            objEntidade.COD_PERFIL = model.CodigoPerfil;
            objEntidade.DSC_EMAIL = model.DescricaoEmail;
            objEntidade.DSC_LOGIN = model.DescricaoLogin;
            objEntidade.DSC_SENHA = model.DescricaoSenha;
            objEntidade.DSC_USUARIO = model.DescricaoUsuario;
            objEntidade.DTA_CADASTRO = System.DateTime.Now;
            objEntidade.DTA_EXPIRACAO = model.DataExpiracao;
            objEntidade.IND_ATIVO = 1;
            Context.TEC_USUARIO.Add(objEntidade);
             Context.SaveChanges();

             return objEntidade.COD_USUARIO;

        }


        public List<Usuarios> Listar(string NomeUsuario)
        {


            List<Usuarios> data = (from usuario in Context.TEC_USUARIO
                                   join p in Context.TEC_PERFIL on usuario.COD_PERFIL equals p.COD_PERFIL
                                   where usuario.DSC_USUARIO.Contains(NomeUsuario)
                                   select new Usuarios
                                   {
                                       CodigoUsuario = usuario.COD_USUARIO,
                                       DescricaoUsuario = usuario.DSC_USUARIO,
                                       DescricaoEmail = usuario.DSC_EMAIL,
                                       DescricaoLogin = usuario.DSC_LOGIN,
                                       DescricaoSenha = usuario.DSC_SENHA,
                                       CodigoEmpresa = usuario.COD_EMPRESA,
                                       DataCadastro = usuario.DTA_CADASTRO,
                                       DataExpiracao = usuario.DTA_EXPIRACAO,
                                       IndicadorAtivo = usuario.IND_ATIVO,
                                       DescricaoPerfil = p.DSC_PERFIL
                                   }).ToList<Usuarios>();

            return data;

        }    


       public List<Usuarios> Listar(int CodigoEmpresa, string NomeUsuario)
        {
            

            List<Usuarios> data = (from usuario in Context.TEC_USUARIO
                                   join p in Context.TEC_PERFIL on usuario.COD_PERFIL equals p.COD_PERFIL
                                   where usuario.DSC_USUARIO.Contains(NomeUsuario) && usuario.COD_EMPRESA == CodigoEmpresa
                                    select new Usuarios
                                   {
                                       CodigoUsuario= usuario.COD_USUARIO,
                                        DescricaoUsuario=usuario.DSC_USUARIO,
                                        DescricaoEmail=usuario.DSC_EMAIL,
                                        DescricaoLogin=usuario.DSC_LOGIN,
                                        DescricaoSenha=usuario.DSC_SENHA,
                                        CodigoEmpresa=usuario.COD_EMPRESA,
                                        DataCadastro =usuario.DTA_CADASTRO,
                                        DataExpiracao=usuario.DTA_EXPIRACAO,
                                        IndicadorAtivo=usuario.IND_ATIVO,
                                        DescricaoPerfil=p.DSC_PERFIL
                                   }).ToList<Usuarios>();

            return data;

        }    

        public List<Usuarios> Listar(int CodigoUsuario)
        {
            

            List<Usuarios> data = (from usuario in Context.TEC_USUARIO
                                   where usuario.COD_USUARIO == CodigoUsuario
                                   join p in Context.TEC_PERFIL on usuario.COD_PERFIL equals p.COD_PERFIL
                                   select new Usuarios
                                   {
                                       CodigoUsuario = usuario.COD_USUARIO,
                                       DescricaoUsuario = usuario.DSC_USUARIO,
                                       DescricaoEmail = usuario.DSC_EMAIL,
                                       DescricaoLogin = usuario.DSC_LOGIN,
                                       DescricaoSenha = usuario.DSC_SENHA,
                                       CodigoEmpresa = usuario.COD_EMPRESA,
                                       DataCadastro = usuario.DTA_CADASTRO,
                                       DataExpiracao = usuario.DTA_EXPIRACAO,
                                       IndicadorAtivo = usuario.IND_ATIVO,
                                       DescricaoPerfil = p.DSC_PERFIL
                                   }).ToList<Usuarios>();

            return data;

        }
                              
        public void Excluir(int Codigo)
        {
           

            TEC_USUARIO obj = (from p in Context.TEC_USUARIO.Where(p => (p.COD_USUARIO == Codigo)) select p).FirstOrDefault();  ///where p =>(p.COD_TENTATIVA == CodigoTentativa || p.COD_PERGUNTA = CodigoPergunta) select p).FirstOrDefault();

            Context.TEC_USUARIO.Remove(obj);
            Context.SaveChanges();

        }        

        public void Atualizar(Usuarios model)
        {

            TEC_USUARIO objEntidade = (from p in Context.TEC_USUARIO.Where((p => p.COD_USUARIO == model.CodigoUsuario)) select p).FirstOrDefault();

            objEntidade.COD_EMPRESA = model.CodigoEmpresa;
            objEntidade.COD_PERFIL = model.CodigoPerfil;
            objEntidade.DSC_EMAIL = model.DescricaoEmail;
            objEntidade.DSC_LOGIN = model.DescricaoLogin;
            objEntidade.DSC_SENHA = model.DescricaoSenha;
            objEntidade.DSC_USUARIO = model.DescricaoUsuario;
            objEntidade.DTA_CADASTRO = System.DateTime.Now;
            objEntidade.DTA_EXPIRACAO = model.DataExpiracao;
            objEntidade.IND_ATIVO = 1;
       
            Context.SaveChanges();            

        }   

    }
}