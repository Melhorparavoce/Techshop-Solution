using Techshop.Repositoy.CodeFirst;
using Techshop.Model;  
using System.Collections.Generic;
using System.Collections;

namespace Techshop.Aplication
{
    public class AppUsuario
    {
        #region Propriedades
        private UsuarioRep objUsuarioRep;
        public AppUsuario()
        {
            objUsuarioRep = new UsuarioRep();

        }

        #endregion

        #region Métodos
      
        public List<Usuario> Listar(string Login,string Senha)
        {
            return (List<Usuario>)objUsuarioRep.Listar(where => where.DescricaoLogin == Login && where.DescricaoSenha== Senha);
               
        }

        public List<Usuario> Listar(int CodigoUsuario)
        {
            return (List<Usuario>)objUsuarioRep.Listar(where => where.CodigoUsuario == CodigoUsuario);

        }
        #endregion

    }

}
