using System;
using System.Collections.Generic;

namespace SkyHubAdapter.Domain.SkyHub
{
    public class TestOrder
    {
        public string channel { get; set; }
        public List<TestOrderItem> items { get; set; }
        public Customer customer { get; set; }
        public Address billing_address { get; set; }
        public Address shipping_address { get; set; }
        public string shipping_method { get; set; }
        public DateTime estimated_delivery { get; set; }
        public double shipping_cost { get; set; }
        public double interest { get; set; }
    }

    public class TestOrderItem
    {
        public string id { get; set; }
        public double qty { get; set; }
    }
}
