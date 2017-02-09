using Techshop.Model;
using System.Linq;
using System.Data;
namespace Techshop.Repositoy.CodeFirst
{
    public class ItemPedidosProtheusRep : RepositorioGenerico<ItemPedidoProtheus>
    {

        #region Propriedades
        private TechshopContext context;   

        public ItemPedidosProtheusRep()
        {

            context = new TechshopContext();  
        }

        #endregion

        #region Métodos
        public void ExcluirTodos()
        {
            var rows = from o in context.ItemPedidoProtheus
                       select o;

            foreach (var row in rows)
            {
                context.ItemPedidoProtheus.Remove(row);
            }  
            context.SaveChanges();

        }
        #endregion

    }
}
