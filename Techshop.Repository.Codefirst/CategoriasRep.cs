using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using System.Data.SqlClient;
using Techshop.Model;

namespace Techshop.Repositoy.CodeFirst
{
    public class CategoriaRep : RepositorioGenerico<Logerro>
    {
        #region  Propriedades
        private TechshopContext context;
        public CategoriaRep()
        {
            context = new TechshopContext();
        }

        #endregion


        #region Métodos

        public List<Categoria> Listar()
        {

            List<Categoria> list= (from c in context.Categorias
                                           orderby c.DescricaoCategoria
                                           select new 
                                           {
                                               CodigoCategoria = c.CodigoCategoria,
                                               DescricaoCategoria = c.DescricaoCategoria
                                           }).ToList()
                                           .Select(x => new Categoria()
                                           {
                                               CodigoCategoria=x.CodigoCategoria,
                                               DescricaoCategoria=x.DescricaoCategoria

                                           }).ToList<Categoria>();

    
            return list;
        }


        public string ListarNomeCategoria(int CodigoSubCategoria)
        {

            var Nome = (from c in context.Categorias
                        join s in context.SubCategorias
                        on c.CodigoCategoria equals s.CodigoCategoria
                        where s.CodigoSubCategoria == CodigoSubCategoria
                        select c.CodigoCategoria
                        ).FirstOrDefault();


            return Nome.ToString();
        }


        #endregion

    }
}
