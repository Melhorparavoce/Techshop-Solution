using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.EntityClient;

namespace Model.CodeFirst.Models
{


    public class Endereco
    {
        [Key]
        [Column(Order = 1)]
        public int CodigoEndereco { get; set; }
        public int CodigoPedido { get; set; }

        [StringLength(250)]
        public string DescricaoBairro { get; set; }

        [StringLength(200)]
        public string DescricaoCep { get; set; }

        [StringLength(300)]
        public string DescricaoCidade { get; set; }

        [StringLength(200)]
        public string DescricaoDetalhes { get; set; }

        [StringLength(250)]
        public string DescricaoNome { get; set; }

        [StringLength(50)]
        public string DescricaoPais { get; set; }

        [StringLength(250)]
        public string DescricaoRegiao { get; set; }

        [StringLength(450)]
        public string DescricaoRua { get; set; }


        public int IndicadorTipoEndereco { get; set; }





    }
}
