using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Techshop.Model
{
    public class Funcionalidades
    {
         public Funcionalidades()
        {
            Usuarios = new HashSet<Usuario>();
            
        }
        [Key]
        [Column(Order=1)]
        public int CodigoFuncionalidade { get; set; }

        public string DescricaoFuncionalidade { get; set; } 

        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}
