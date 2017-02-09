using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BD.Techshop;
using Model.Techshop;

namespace BO.Techshop
{
    public class BOMenu
    {

        public List<Usuarios> RetornaMenuAdministrador(int CodigoEmpresa, int CodigoUsuario)
        {
            BDUsuario objBDUsuario = new BDUsuario();
            List<Usuarios> list = objBDUsuario.ListarPermissoes(CodigoEmpresa, CodigoUsuario);

            if (list[0].CodigoPerfil == 3)
                return null;
            else
                return list;

        }

        
    }
}