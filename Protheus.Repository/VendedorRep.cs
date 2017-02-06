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

        public List<Vendedor> Consulta(string CodigoProduto)
        {
            List<Vendedor> lista = Listar(where => where.CodigoProduto.Contains(CodigoProduto)).ToList();

            return lista;
        }      

        #endregion



    }
}
