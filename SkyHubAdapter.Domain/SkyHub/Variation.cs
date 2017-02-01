using System.Collections.Generic;

namespace SkyHubAdapter.Domain.SkyHub
{
    public class Variation
    {
        public string sku { get; set; }
        public int qty { get; set; }
        public string ean { get; set; }
        public List<string> images { get; set; }
        public List<Specification> specifications { get; set; }
        public List<Marketplaces> marketplaces { get; set; }
    }
}
