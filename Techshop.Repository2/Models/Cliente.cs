using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.EntityClient;

namespace Model.CodeFirst.Models
{             

       /*   obj.COD_PEDIDO = domain.CodigoPedido;
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
            context.SaveChanges(); */




    public class Cliente
    { 
        [Key]
        [Column(Order = 1)]
        public int CodigoCliente { get; set; }
        public int CodigoPedido { get; set; }
        [StringLength(250)]
        public string DescricaoCliente { get; set; }
        [StringLength(250)]
        public string DescricaoEmail { get; set; }
        [StringLength(30)]
        public string DescricaoGenero { get; set; }
        [StringLength(50)]
        public string DescricaoCPF { get; set; }
        [StringLength(50)]
        public string DescricaoTelefone1 { get; set; }

        [StringLength(50)]
         public string DescricaoTelefone2 { get; set; }
        [StringLength(50)]
        public string DescricaoTelefone3 { get; set; }
        [StringLength(50)]
        public string DescricaoTelefone4 { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataNascimento2 { get; set; }


    }
}
