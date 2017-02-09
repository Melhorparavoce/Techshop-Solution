using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Techshop.Model
{
   public class Usuario
    {


        public Usuario()
        {

            FuncionalidadesUsuario = new HashSet<Funcionalidades>();

        }
        [Key]
        [Column(Order = 1)]
        public int CodigoUsuario { get; set; }
     
        [StringLength(100)]
        public string DescricaoUsuario { get; set; }

        [StringLength(100)]
        public string DescricaoLogin { get; set; }

        [StringLength(100)]
        public string DescricaoEmail { get; set; }

        [StringLength(50)]
        public string DescricaoSenha { get; set; }

        public System.DateTime DataCadastro { get; set; }

        public ICollection<Funcionalidades> FuncionalidadesUsuario { get; set; }
        
    }
}
