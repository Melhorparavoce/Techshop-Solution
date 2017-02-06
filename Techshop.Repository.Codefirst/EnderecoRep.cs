using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using Model.CodeFirst.Models;

namespace Techshop.Repositoy.CodeFirst
{
    public class EnderecoRep
    {

        private TechshopContext context;

        public EnderecoRep()
        {

            context = new TechshopContext();

        }

        public void incluir(Address domain)
          {

              Endereco obj = new Endereco();

              obj.CodigoPedido = domain.CodigoPedido;
              obj.DescricaoBairro = domain.neighborhood;
              obj.DescricaoCep = domain.postcode;
              obj.DescricaoCidade = domain.city;
              obj.DescricaoDetalhes = domain.detail;
              obj.DescricaoNome = domain.full_name;
              obj.DescricaoPais = domain.country;
              obj.DescricaoRegiao = domain.region;
              obj.DescricaoRua = domain.street;
              obj.IndicadorTipoEndereco = domain.TipoEndereco;
              context.Endereco.Add(obj);
              context.SaveChanges(); 


          }          

    }
}
