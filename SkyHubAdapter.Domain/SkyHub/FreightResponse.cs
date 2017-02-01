using System.Collections.Generic;

namespace SkyHubAdapter.Domain.SkyHub
{
    public class FreightResponse
    {
        public string render { get; set; }
        public List<Product> products { get; set; }
    }
}
