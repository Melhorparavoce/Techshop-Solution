using System;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Repositoy.CodeFirst;
using Techshop.Model;
using System.Collections.Generic;
using Protheus.Repository;

namespace Techshop.Aplication
{
    public class CategoriasApp
    {
        #region Propriedades
        private CategoriaRep objCategoriaRep;
        private SubCategoriasRep objSubCategoriasRep;

        public CategoriasApp()
        {
            objCategoriaRep = new CategoriaRep();
            objSubCategoriasRep = new SubCategoriasRep();

        }

        #endregion

        #region Métodos


        public List<Categoria> Listar()
        {
            List<Categoria> list = objCategoriaRep.Listar();

            return list;
        }

        public List<SubCategoria> ListarSubCategorias(int CodigoSubCategoria)
        {
            List<SubCategoria> list = (List<SubCategoria>)objSubCategoriasRep.Listar(where => where.CodigoSubCategoria == CodigoSubCategoria);

            return list;
        }

        public List<SubCategoria> ListarSubCategoriasPorCodigoCategoria(int CodigoCategoria)
        {
            List<SubCategoria> list = (List<SubCategoria>)objSubCategoriasRep.Listar(where => where.CodigoCategoria == CodigoCategoria);

            return list;
        }


        public string ListarNomeCategoria(int CodigoSubCategoria)
        {
            return objCategoriaRep.ListarNomeCategoria(CodigoSubCategoria);

        }

        public List<SubCategoria> ListarCategoria(int CodigoSubCategoria)
        {
            return (List<SubCategoria>)objSubCategoriasRep.Listar(where => where.CodigoSubCategoria == CodigoSubCategoria);

        }

        #endregion

    }

}
