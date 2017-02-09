using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Model;
namespace Techshop.Repositoy.CodeFirst
{
    public class ItemPedidoRep : RepositorioGenerico<ItemPedidos>
    {

        #region Propriedades

        private TechshopContext context;   

        public ItemPedidoRep()          {

            context = new TechshopContext();  
        }

        #endregion

        #region Métodos

        public List<ItemPedidos> Listar(int CodigoPedido)
        {
            return Listar(where => where.CodigoPedido == CodigoPedido).ToList();

        }                                                   
                                                                              
        public void CriarItemPedido(ItemPedidos EntidadeItemPedido)
        {  
            context.ItemsPedido.Add(EntidadeItemPedido);
            context.SaveChanges();          
              
        }

        public void ExcluirTodos()
        {
            var rows = from o in context.ItemsPedido
                       select o;

            foreach (var row in rows)
            {
                context.ItemsPedido.Remove(row);
            }
            context.SaveChanges();

        }

        #endregion

    }
}
