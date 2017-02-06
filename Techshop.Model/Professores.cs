using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Techshop.Model
{
   public class Professores
    {

        public Professores()
        {
            Alunos = new List<Aluno>();  
        }

        [Key]
        [Column(Order = 1)]
        public int CodigoProfessor { get; set; }
     
        [StringLength(100)]
        public string DescricaoProfessor { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
