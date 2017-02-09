using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Util.Techshop
{
    public class VariaveisGlobais
    {
        public static int CodigoEmpresa
        {
            get
            {
                return System.Convert.ToInt32(HttpContext.Current.Application["CodigoEmpresa"]);
            }
            set
            {
                HttpContext.Current.Application["CodigoEmpresa"] = value;
            }
        }

        public static int CodigoUsuario
        {
            get
            {
                return System.Convert.ToInt32(HttpContext.Current.Application["CodigoUsuario"]);
            }
            set
            {
                HttpContext.Current.Application["CodigoUsuario"] = value;
            }
        }   
   
    }
    
}