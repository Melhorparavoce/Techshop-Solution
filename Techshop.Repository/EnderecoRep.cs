using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;

namespace Techshop.Repository
{
    public class EnderecoRep
    {

        TechshopEntities1 context = new TechshopEntities1();

      public void incluir(Address domain)
        {

            TEC_ENDERECO obj = new TEC_ENDERECO();
            
            obj.COD_PEDIDO = domain.CodigoPedido;
            obj.DSC_BAIRRO = domain.neighborhood;
            obj.DSC_CEP = domain.postcode;
            obj.DSC_CIDADE = domain.city;
            obj.DSC_DETALHES = domain.detail;
            obj.DSC_NOME = domain.full_name;
            obj.DSC_PAIS = domain.country;
            obj.DSC_REGIAO = domain.region;
            obj.DSC_RUA = domain.street;
            obj.IND_ATIVO = 1;
            obj.IND_TIPO_ENDERECO = domain.TipoEndereco;
            obj.DSC_TIPO_ENDERECO = domain.DescricaoEndereco;
            context.TEC_ENDERECO.Add(obj);
            context.SaveChanges();

           
        }        

    }
}
