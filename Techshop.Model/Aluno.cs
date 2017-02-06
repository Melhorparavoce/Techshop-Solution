using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Techshop.Model
{
   public class Aluno
    {
        [Key]
        [Column(Order = 1)]
        public int CodigoAluno { get; set; }
     
        [StringLength(100)]
        public string DescricaoAluno { get; set; }

        public virtual Professores Professores { get; set; }
    }
}
