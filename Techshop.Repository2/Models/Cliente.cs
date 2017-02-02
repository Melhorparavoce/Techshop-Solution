using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.EntityClient;

namespace Model.CodeFirst.Models
{             
    /*
            obj.DSC_NOME = domain.full_name;
            obj.DSC_PAIS = domain.country;
            obj.DSC_REGIAO = domain.region;
            obj.DSC_RUA = domain.street;
            obj.IND_ATIVO = 1;
            obj.IND_TIPO_ENDERECO = domain.TipoEndereco;
            obj.DSC_TIPO_ENDERECO = domain.DescricaoEndereco;  */

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
