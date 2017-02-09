using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Techshop.Util
{
    public class VariaveisGlobais
    {
                                
        public static int CodigoUsuario
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Application["CodigoUsuario"].ToString());
            }
            set
            {
                HttpContext.Current.Application["CodigoUsuario"] = value;
            }
        }


    }
}
