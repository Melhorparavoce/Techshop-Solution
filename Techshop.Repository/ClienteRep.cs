using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;

namespace Techshop.Repository
{
    public class ClienteRep
    {
        TechshopEntities1 context = new TechshopEntities1();

      public void incluir(Customer domain)
        {  
            TEC_CLIENTES obj = new TEC_CLIENTES();

            obj.COD_PEDIDO = domain.CodigoPedido;
            obj.DSC_CLIENTE = domain.name;
            obj.DSC_EMAIL = domain.email;
            obj.DSC_GENERO = domain.gender;
            obj.DSC_NUMERO_VAT = domain.vat_number;
            obj.DSC_TELEFONE1 = domain.phones[0];
            obj.DSC_TELEFONE2 = domain.phones[1];
            obj.DSC_TELEFONE3 = domain.phones[2];
            obj.DSC_TELEFONE4 = domain.phones[3];
            obj.DTA_NASCIMENTO = Convert.ToDateTime(domain.date_of_birth);  

            context.TEC_CLIENTES.Add(obj);
            context.SaveChanges();

           
        }            

    }
}
