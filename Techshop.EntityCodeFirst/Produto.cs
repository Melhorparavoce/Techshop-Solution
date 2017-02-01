using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Techshop.EntityCodeFirst
{
    [Table("Grupo")]
    public class Produto
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public string Descricao { get; set; }
        public int GrupoID { get; set; }
    
        [ForeignKey("GrupoID")]
        public virtual Grupo Grupo { get; set; }        

    }
}
