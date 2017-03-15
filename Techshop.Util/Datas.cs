using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techshop.Util
{
    public class Datas  
    {

        public static DateTime AlteraFormatoDataMMddAAA(string Data)
        {

            string Dia = Data.Split('/')[0];
            string Mes = Data.Split('/')[1];
            string Ano = Data.Split('/')[2];

            return  Convert.ToDateTime(Mes + "/" + Dia + "/" + Ano);

        }

        public static DateTime AlteraFormatoDataddMMaaaa(string Data)
        {

            string Mes = Data.Split('/')[0];
            string Dia = Data.Split('/')[1];
            string Ano = Data.Split('/')[2];

            return Convert.ToDateTime(Dia + "/" + Mes + "/" + Ano);



        }
    }
}
