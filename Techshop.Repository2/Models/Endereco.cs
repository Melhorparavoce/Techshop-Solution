using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.EntityClient;

namespace Model.CodeFirst.Models
{             
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

      


    }
}
