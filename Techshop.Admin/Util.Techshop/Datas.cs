using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Util.Techshop
{
    public static class Datas
    {
        public static string AlteraFormatoDataMMddAAA(string Data)
        {

            string Dia = Data.Split('/')[0];
            string Mes = Data.Split('/')[1];
            string Ano = Data.Split('/')[2];

            return Mes + "/" + Dia + "/" + Ano;              

        }

        public static string AlteraFormatoDataddMMaaaa(string Data)
        {

            string Mes = Data.Split('/')[0];
            string Dia = Data.Split('/')[1];
            string Ano = Data.Split('/')[2];

            return Dia + "/" + Mes + "/" + Ano;



        }
     
    }
}