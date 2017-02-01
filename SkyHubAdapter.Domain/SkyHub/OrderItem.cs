namespace SkyHubAdapter.Domain.SkyHub
{
    public class OrderItem
    {
        public int CodigoPedido { get; set; }
        public string id { get; set; }
        public string product_id { get; set; }
        public string name { get; set; }
        public double qty { get; set; }
        public double original_price { get; set; }
        public double special_price { get; set; }
    }
}
