using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Techshop.Model
{
   public class Categoria
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoCategoria { get; set; }

        public string DescricaoCategoria { get; set; }     

    }
}
