using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techshop.Model;
namespace Protheus.Repository
{
    public class VendedorRep
    {
          
        #region Propriedades
            private ProtheusContext context;

            public VendedorRep()
            {
                context = new ProtheusContext();

            }
        #endregion

        #region Métodos

        public void Consulta()
        {
            var query = context.VendedorNovo;

            string teste = "";


        }      

        #endregion



    }
}
