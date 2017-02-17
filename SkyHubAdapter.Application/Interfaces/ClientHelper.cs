using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Formatters;
using System.Text;
using Newtonsoft.Json;
using SkyHubAdapter.Domain.AbsModels;

namespace SkyHubAdapter.Application.Interfaces
{
    public class ClientHelper 
    {

        private static readonly SkyHubClient Client = new SkyHubClient();
        
         /// <summary>
        /// Realiza um POST
        /// </summary>
        /// <returns>
        /// 201	Requisição executada com sucesso	
        /// 400	Requisição mal-formada	
        /// 401	Erro de autenticação	
        /// 500	Erro na API
        /// </returns>
        public static ResultProcessing Post<T>(T newModel, string uri)
        {
           
            var result = new ResultProcessing();

            //Serializando em JSon
            var json = JsonConvert.SerializeObject(newModel, 
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
                });

            //Criando o elemento root, caso não seja anônimo
            if (!newModel.GetType().Name.ToLower().Contains("anonymoustype"))
                json = "{\"" + newModel.GetType().Name.ToLower() + "\":" + json + "}";
            var content = new StringContent(json
                , Encoding.UTF8, "application/json");

            //var response = Client.PostAsJsonAsync(uri, newModel);
            
            //Realizando o post
            var response = Client.PostAsync(uri, content);
            var responseResult = response.Result;

            result.Success = responseResult.IsSuccessStatusCode;
            result.StatusCode = responseResult.StatusCode;
            result.Message = responseResult.Content.ReadAsStringAsync().Result;

            return result;
        }

        /// <summary>
        /// Realiza um PUT
        /// </summary>
        /// <typeparam name="T">Tipo a ser atualizado</typeparam>
        /// <param name="model">Tipo a ser atualizado</param>
        /// <param name="uri">Url da requisição</param>
        /// <returns></returns>
        public static ResultProcessing Put<T>(T model, string uri)
        {
            var result = new ResultProcessing();

            //Serializando em JSon
            var json = JsonConvert.SerializeObject(model,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
                });

            //Criando o elemento root, caso não seja anônimo
            if (!model.GetType().Name.ToLower().Contains("anonymoustype"))
                json = "{\"" + model.GetType().Name.ToLower() + "\":" + json + "}";
            var content = new StringContent(json
                , Encoding.UTF8, "application/json");

            var response = Client.PutAsync(uri, content);
            var responseResult = response.Result;
            //var response = Client.PutAsJsonAsync(uri, model).Result;

            result.Success = responseResult.IsSuccessStatusCode;
            result.StatusCode = responseResult.StatusCode;
            result.Message = responseResult.Content.ReadAsStringAsync().Result;

            return result;
        }

        /// <summary>
        /// Retorna um registro ou uma lista
        /// </summary>
        /// <typeparam name="T">Tipo de Objeto</typeparam>
        /// <param name="code">Valor do Id</param>
        /// <param name="isList">Retorna uma lista ou não</param>
        /// <param name="uri">Url da requisição</param>
        /// <returns>
        /// 200 Requisição executada com sucesso
        /// 401	Erro de autenticação	
        /// 404	Recurso não encontrado
        /// 500	Erro na API
        /// </returns>
        public static ResultProcessing Get<T>(string uri, string code = "", bool isList = true)
        {
            var result = new ResultProcessing { AdditionalData = null };
            var resource = string.Format("{0}/{1}",uri,code);
            var response = Client.GetAsync(resource).Result;
              
            result.Success = response.IsSuccessStatusCode;
            result.StatusCode = response.StatusCode;
            result.Message = response.Content.ReadAsStringAsync().Result;

            if (!result.Success) return result;
            if (isList)
                result.AdditionalData = response.Content.ReadAsAsync<List<T>>().Result;
            else
                result.AdditionalData = response.Content.ReadAsAsync<T>().Result;

            return result;
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="uri">Url da requisição</param>
        /// <param name="code">Id do registro</param>
        /// <returns></returns>
        public static ResultProcessing Delete(string uri, string code)
        {
            var result = new ResultProcessing();
            var resource = string.Format("{0}/{1}", uri, code);
            var response = Client.DeleteAsync(resource).Result;

            result.Success = response.IsSuccessStatusCode;
            result.StatusCode = response.StatusCode;
            result.Message = response.Content.ReadAsStringAsync().Result;

            return result;
        }



        
    }

}
