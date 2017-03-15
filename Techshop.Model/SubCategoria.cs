using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Techshop.Model
{
   public class SubCategoria
    {
        [Key]
        [Column(Order = 1)]
        public int CodigoSubCategoria { get; set; }

        public string DescricaoSubCategoria { get; set; }

        public int CodigoCategoria { get; set; }

    }
}
