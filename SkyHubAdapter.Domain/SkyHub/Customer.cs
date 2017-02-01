using System.Collections.Generic;

namespace SkyHubAdapter.Domain.SkyHub
{
    public class Customer
    {
        public int CodigoPedido { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string date_of_birth { get; set; }
        public string gender { get; set; }
        public string vat_number { get; set; }
        public List<string> phones { get; set; }
    }
}
