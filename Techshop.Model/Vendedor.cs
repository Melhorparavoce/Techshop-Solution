using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Techshop.Model
{
    public class Vendedor
    {

        [Key]
        public string CodigoProduto { get; set; }
        public string VendedorB2W { get; set; }
        public string VendedorCNOVA { get; set; }
        public string VendedorTechshop { get; set; }
    }
}
