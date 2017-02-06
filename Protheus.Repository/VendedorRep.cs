using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techshop.Model;
namespace Protheus.Repository
{
    public class VendedorRep:RepositorioGenerico<Vendedor>
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
            List<Vendedor> lista = Listar(where => where.CodigoVedendor == 1).ToList();

            string teste = "";


        }      

        #endregion



    }
}
