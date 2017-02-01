using System.Collections.Generic;

namespace SkyHubAdapter.Domain.SkyHub
{
    public class Product
    {
        public string sku { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public int qty { get; set; }
        public double price { get; set; }
        public double? promotional_price { get; set; }
        public double cost { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public double width { get; set; }
        public double length { get; set; }
        public string brand { get; set; }
        public string ean { get; set; }
        public string nbm { get; set; }
        public List<Category> categories { get; set; }
        public List<string> images { get; set; }
        public List<Specification> specifications { get; set; }
        public List<Variation> variations { get; set; }
        public List<string> variation_attributes { get; set; }
        public List<Marketplaces> marketplaces { get; set; }
        public List<Freight> freights { get; set; }

        public class ProductListResponse
        {
            public List<Product> Products { get; set; }
            public int Total { get; set; }
        }
    }

    
}
