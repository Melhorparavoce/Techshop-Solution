using System;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Repositoy.CodeFirst;
using Techshop.Model;
using System.Collections.Generic;
using Protheus.Repository;
namespace Techshop.Aplication
{
    public class LogerroApp
    {
        #region Propriedades
        private LogerroRep objLogerroRep;
        public LogerroApp()
        {
            objLogerroRep = new LogerroRep();

        }    
        #endregion

        #region Métodos
      
        public void GravarLogErro(string DescricaoOperacao,string DescricaoErro,string DescricaoExcecao)
        {                                          
            var entidade = new Logerro
            {
              DataGeracao = DateTime.Now,
              DescricaoErro = DescricaoErro,
              DescricaoExcecao = DescricaoExcecao,
              DescricaoOperacao = DescricaoOperacao
            };

            objLogerroRep.Criar(entidade);  

        } 

                                                            
        #endregion
       
    }

}
