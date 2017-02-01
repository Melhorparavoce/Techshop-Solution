using System;
using System.Collections.Generic;

namespace SkyHubAdapter.Domain.SkyHub
{
    public class Order
    {
        public string code { get; set; }
        public string channel { get; set; }
        public string placed_at { get; set; }
        public string updated_at { get; set; }
        public double total_ordered { get; set; }
        public double interest { get; set; }
        public double shipping_cost { get; set; }
        public string shipping_method { get; set; }
        public DateTime estimated_delivery { get; set; }
        public Address shipping_address { get; set; }
        public Address billing_address { get; set; }
        public Customer customer { get; set; }
        public List<OrderItem> items { get; set; }
        /// <summary>
        ///  Status de sincronização do pedido. Valores possíveis: "SYNCED", "NOT_SYNCED" e "ERROR",
        /// </summary>
        public Status status { get; set; }
        public string sync_status { get; set; }
        public List<Invoice> invoices { get; set; }
        public List<Shipment> shipments { get; set; }
        public List<Payment> payments { get; set; }

        public class OrderListResponse
        {
            public List<Order> Orders { get; set; }
            public int Total { get; set; }
        }
    }
}
