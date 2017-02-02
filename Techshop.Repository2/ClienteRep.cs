using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyHubAdapter.Domain.SkyHub;
using Model.CodeFirst.Models;
using SkyHubAdapter.Domain.SkyHub;

namespace Techshop.Repositoy.CodeFirst
{
    public class ClienteRep
    {
        private TechshopContext context;  

        public ClienteRep()
        {

            context = new TechshopContext();

        }

        public void IncluirClientesSkyhub(Customer domain)
        {  
            Cliente obj = new Cliente();

            obj.CodigoPedido = domain.CodigoPedido;
            obj.DescricaoCliente = domain.name;
            obj.DescricaoEmail = domain.email;
            obj.DescricaoGenero = domain.gender;
            obj.DescricaoCPF = domain.vat_number;
            obj.DescricaoTelefone1 = domain.phones[0];
            obj.DescricaoTelefone2 = domain.phones[1];
            obj.DescricaoTelefone3 = domain.phones[2];
            obj.DescricaoTelefone4 = domain.phones[3];
            obj.DataNascimento = Convert.ToDateTime(domain.date_of_birth);  

            context.TEC_CLIENTE.Add(obj);
            context.SaveChanges();    

           
        }            

    }
}
