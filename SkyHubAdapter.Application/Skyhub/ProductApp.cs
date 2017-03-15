using SkyHubAdapter.Domain.SkyHub;
using SkyHubAdapter.Application.Interfaces;
using SkyHubAdapter.Domain.AbsModels;

namespace SkyHubAdapter.Application
{
    public class ProductApp : IGenericType<Product>
    {
        private const string Uri = "products";

        /// <summary>
        /// Inclui um produto
        /// </summary>
        /// <returns>
        /// 201	Requisição executada com sucesso	
        /// 400	Requisição mal-formada	
        /// 401	Erro de autenticação	
        /// 500	Erro na API
        /// </returns>
        public ResultProcessing Post(Product newProduct)
        {
            return ClientHelper.Post(newProduct, Uri);
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <returns>
        /// 204	Requisição executada com sucesso
        /// 400	Requisição mal-formada	
        /// 401	Erro de autenticação	
        /// 404	Recurso não encontrado
        /// 500	Erro na API
        /// </returns>
        public ResultProcessing Put(Product product)
        {
            return ClientHelper.Put(product, Uri + "/" + product.sku);
        }

        /// <summary>
        /// Retorna um produto
        /// </summary>
        /// <returns>
        /// 200 Requisição executada com sucesso
        /// 401	Erro de autenticação	
        /// 404	Recurso não encontrado
        /// 500	Erro na API
        /// </returns>
        public ResultProcessing Get(string sku = "")
        {
            return sku == string.Empty ? 
                ClientHelper.Get<Product.ProductListResponse>(Uri, sku, false) : 
                ClientHelper.Get<Product>(Uri, sku, false);
        }

        public ResultProcessing Get(int Pagina,int QuantidadeRegistros, string Sku, string Nome, int QuantidadeInicial, int QuantidadeFinal,string Status)
        {

            return ClientHelper.Get<Product.ProductListResponse>(Uri, "?page="+ Pagina + "&per_page="+ QuantidadeRegistros + "&filters[sku]=" + Sku + "&filters[name]=" + Nome + "&filters[qty_from]=" + QuantidadeInicial + "&filters[qty_to]=" + QuantidadeFinal+ "&filters[status]="+ Status, false);
          
        }


        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <returns>
        /// 204	Requisição executada com sucesso	
        /// 401	Erro de autenticação	
        /// 404	Recurso não encontrado	
        /// 422	Erro semântico	
        /// 500	Erro na API
        /// </returns>
        public ResultProcessing Delete(string sku)
        {
            return ClientHelper.Delete(Uri, sku);
        }

    }



}
