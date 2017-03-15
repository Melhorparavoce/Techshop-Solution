using Techshop.Repositoy.CodeFirst;
using Techshop.Model;  
using System.Collections.Generic;
using System.Collections;
using SkyHubAdapter.Domain.SkyHub;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.AbsModels;
using System;
namespace Techshop.Aplication
{
    public class ProdutoApp
    {
        #region Propriedades

        private ProductApp objProductApp = new ProductApp();
        private SubCategoriasRep objSubCategoriasRep = new SubCategoriasRep();
        private CategoriasApp objCategoriasApp = new CategoriasApp();
         public ProdutoApp()
        {
           

        }

        #endregion

        #region Métodos
      
        public List<Product> Listar(int Pagina,int QuantidadeRegistros, string Sku,string Nome,int QuantidadeInicial,int QuantidadeFinal,string Status)
        {

            ResultProcessing retorno = objProductApp.Get(Pagina, QuantidadeRegistros,Sku, Nome, QuantidadeInicial, QuantidadeFinal,Status);
            int TotalBusca = ((SkyHubAdapter.Domain.SkyHub.Product.ProductListResponse)retorno.AdditionalData).Total;
            List<Product> listRetorno = new List<Product>();

            foreach (Product item in (List<Product>)((Product.ProductListResponse)retorno.AdditionalData).Products)
            {
                
                item.TotalBusca = TotalBusca;
                item.TotalItensPagina = CalculaTotalItensPagina(item, QuantidadeRegistros);
                listRetorno.Add(item);
            }

            return listRetorno;
        }


        public int CalculaTotalItensPagina(Product item, int QuantidadeRegistros)
        {

            double TotalItensPagina;

            if (item.TotalBusca <= QuantidadeRegistros)
            { TotalItensPagina = 1; }
            else { TotalItensPagina = Convert.ToDouble(item.TotalBusca) / Convert.ToDouble(QuantidadeRegistros); }

            return Convert.ToInt32(Math.Ceiling(TotalItensPagina));

        }


        public Product Listar(string SkuProduto)
        {

            Product entidadeProduct = (Product)objProductApp.Get(SkuProduto).AdditionalData;

            string Sku = entidadeProduct.categories[0].code;
            int n;
            bool isNumeric = int.TryParse(Sku, out n);

            if (isNumeric)
                entidadeProduct.CodigoCategoria = objCategoriasApp.ListarSubCategorias(System.Convert.ToInt32(Sku))[0].CodigoCategoria;
            else
                entidadeProduct.CodigoCategoria = 0;

          

            int TotalImagens = entidadeProduct.images.Count;
            for (int i = 0; i < (6 - TotalImagens); i++)
            {
                entidadeProduct.images.Add("");
            }

            int TotaEspecificacoes = entidadeProduct.specifications.Count;

            for (int j = 0; j < TotaEspecificacoes; j++)
            {
                if (j == 0)
                    entidadeProduct.Cor = entidadeProduct.specifications[0].value;
                if (j == 1)
                    entidadeProduct.Tamanho = entidadeProduct.specifications[1].value;
                if (j == 2)
                    entidadeProduct.Voltagem = entidadeProduct.specifications[2].value;

            }

            return entidadeProduct;
        }


        public ResultProcessing Gravar(List<string> VariacoesProduto,List<Variation> listVariation,List<Specification> listEspecificacoes, Product objProduct,int CodigoCategoria,List<string> ListaImagens)
        {
            SubCategoria objSubCategoria = objSubCategoriasRep.Listar(where => where.CodigoSubCategoria == CodigoCategoria)[0];

            var newProduct = new Product
            {
                description = objProduct.description,
                cost = 0,
                ean = objProduct.ean,
                height = objProduct.height,
                width = objProduct.width,
                length = objProduct.length,
                weight = objProduct.weight,
                name = objProduct.name,
                price = objProduct.price,
                promotional_price = objProduct.promotional_price,
                qty = objProduct.qty,
                images = ListaImagens,
                sku = objProduct.sku,
                status = "enabled",
                categories = new List<Category> { new Category { code = objSubCategoria.CodigoSubCategoria.ToString(), name = objSubCategoria.DescricaoSubCategoria } },
                variations = listVariation,
                variation_attributes= VariacoesProduto,
                brand = "",
                specifications = listEspecificacoes
            };

            return new ProductApp().Post(newProduct);


        }


        public ResultProcessing Atualizar(List<string> VariacoesProduto, List<Variation> listVariation, List<Specification> listEspecificacoes, Product objProduct, int CodigoCategoria, List<string> ListaImagens)
        {
            SubCategoria objSubCategoria = objSubCategoriasRep.Listar(where => where.CodigoSubCategoria == CodigoCategoria)[0];

            var newProduct = new Product
            {
                description = objProduct.description,
                cost = 0,
                ean = objProduct.ean,
                height = objProduct.height,
                width = objProduct.width,
                length = objProduct.length,
                weight = objProduct.weight,
                name = objProduct.name,
                price = objProduct.price,
                promotional_price = objProduct.promotional_price,
                qty = objProduct.qty,
                images = ListaImagens,
                sku = objProduct.sku,
                status = objProduct.status,
                categories = new List<Category> { new Category { code = objSubCategoria.CodigoSubCategoria.ToString(), name = objSubCategoria.DescricaoSubCategoria } },
                variations = listVariation,
                variation_attributes = VariacoesProduto,
                brand = "",
                specifications = listEspecificacoes
            };

             return new ProductApp().Put(newProduct);

        }


        #endregion

    }

}
