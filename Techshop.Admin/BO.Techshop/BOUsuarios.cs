using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BD.Techshop;
using Model.Techshop;
using Util.Techshop;
using System.Web;
using System;
using System.Collections.Generic;
using System.Web.Security;
                         
namespace BO.Techshop
{
    public class BOUsuarios
    {


        public bool AutenticarUsuario(string Login, string Senha)
        {
            BDUsuario objBD = new BDUsuario();

            if (objBD.Listar(Login, Senha).Count == 1)
            {
                FormsAuthentication.SetAuthCookie(Login + Senha, false);
                VariaveisGlobais.CodigoEmpresa = objBD.Listar(Login, Senha)[0].CodigoEmpresa;
                VariaveisGlobais.CodigoUsuario = objBD.Listar(Login, Senha)[0].CodigoUsuario;

                return true;
            }
            else
            {
                return false;

            }

        }   

        public List<Usuarios> Listar(int CodigoUsuario)
        {
            BDUsuario objBDUsuario = new BDUsuario();
            List<Usuarios> ListUsuarios = objBDUsuario.Listar(CodigoUsuario);
            return ListUsuarios;

        }


        public void GravarUsuario(Usuarios EntidadeUsuario)
        {
            BDUsuario objBDUsuario = new BDUsuario();

            int CodigoUsuario = objBDUsuario.Incluir(EntidadeUsuario);

            string Sucesso = "";
        }

        public void Atualizar(Usuarios model)
        {

            BDUsuario objBDUsuario = new BDUsuario();

            objBDUsuario.Atualizar(model);

           /* objBDUsuario.ExcluirPermissoesUsuario(model.CodigoUsuario);

            string[] Exame = model.ExamesSelecionados.Split(';');
            foreach (string item in Exame)
            {
                if (item != "")
                {
                    objBDUsuario.InserirUsuarioExame(model.CodigoUsuario, Convert.ToInt32(item));
                }
            }    */
        
            

        }

    } 

}