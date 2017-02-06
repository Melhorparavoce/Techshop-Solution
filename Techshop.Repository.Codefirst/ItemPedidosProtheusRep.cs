
using Techshop.Model;
namespace Techshop.Repositoy.CodeFirst
{
    public class ItemPedidosProtheusRep : RepositorioGenerico<ItemPedidoProtheus>
    {

         private TechshopContext context;   

        public ItemPedidosProtheusRep()
        {

            context = new TechshopContext();  
        }

      
    }
}
