using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
   
namespace Techshop.EntityCodeFirst
{
    public class Grupo    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public string Nome { get; set; }
    
        public virtual IQueryable<Produto> Produtos { get; set; }
    }
}
